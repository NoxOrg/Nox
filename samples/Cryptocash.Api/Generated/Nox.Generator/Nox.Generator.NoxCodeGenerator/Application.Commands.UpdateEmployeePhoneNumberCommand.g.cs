﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record UpdateEmployeePhoneNumberCommand(EmployeeKeyDto ParentKeyDto, EmployeePhoneNumberDto EntityDto) : IRequest <EmployeePhoneNumberKeyDto?>;

public partial class UpdateEmployeePhoneNumberCommandHandler: CommandBase<UpdateEmployeePhoneNumberCommand, EmployeePhoneNumber>, IRequestHandler <UpdateEmployeePhoneNumberCommand, EmployeePhoneNumberKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<EmployeePhoneNumber> EntityMapper { get; }

	public UpdateEmployeePhoneNumberCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<EmployeePhoneNumber> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<EmployeePhoneNumberKeyDto?> Handle(UpdateEmployeePhoneNumberCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		
				var keyId = CreateNoxTypeForKey<Employee,DatabaseNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Employees.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		
				var ownedId = CreateNoxTypeForKey<EmployeePhoneNumber,DatabaseNumber>("Id", request.EntityDto.Id);
		var entity = parentEntity.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<EmployeePhoneNumber>(), request.EntityDto);
		
		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new EmployeePhoneNumberKeyDto(entity.Id.Value);
	}
}