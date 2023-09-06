﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Employee = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public record UpdateEmployeeCommand(System.Int64 keyId, EmployeeUpdateDto EntityDto, System.Guid? Etag) : IRequest<EmployeeKeyDto?>;

public class UpdateEmployeeCommandHandler: CommandBase<UpdateEmployeeCommand, Employee>, IRequestHandler<UpdateEmployeeCommand, EmployeeKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Employee> EntityMapper { get; }
	public IEntityMapper<EmployeePhoneNumber> EmployeePhoneNumberEntityMapper { get; }

	public UpdateEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,	
			IEntityMapper<EmployeePhoneNumber> entityMapperEmployeePhoneNumber,
		IEntityMapper<Employee> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;	
		EmployeePhoneNumberEntityMapper = entityMapperEmployeePhoneNumber;
		EntityMapper = entityMapper;
	}
	
	public async Task<EmployeeKeyDto?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<Employee>(), request.EntityDto);
		foreach(var ownedEntity in request.EntityDto.EmployeePhoneNumbers)
		{
			UpdateEmployeePhoneNumber(entity, ownedEntity);
		}
		entity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeeKeyDto(entity.Id.Value);
	}
	private void UpdateEmployeePhoneNumber(Employee parent, EmployeePhoneNumberDto child)
	{
		var ownedId = CreateNoxTypeForKey<EmployeePhoneNumber,DatabaseNumber>("Id", child.Id);

		var entity = parent.EmployeePhoneNumbers.SingleOrDefault(x =>
			x.Id.Equals(ownedId) &&
			true);
		if (entity == null)
		{
			return;
		}

		EmployeePhoneNumberEntityMapper.MapToEntity(entity, GetEntityDefinition<EmployeePhoneNumber>(), child);		
	}
}