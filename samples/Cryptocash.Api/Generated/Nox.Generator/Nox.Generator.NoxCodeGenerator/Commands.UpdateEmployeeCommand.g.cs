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

public record UpdateEmployeeCommand(System.Int64 keyId, EmployeeUpdateDto EntityDto) : IRequest<EmployeeKeyDto?>;

public class UpdateEmployeeCommandHandler: CommandBase<UpdateEmployeeCommand, Employee>, IRequestHandler<UpdateEmployeeCommand, EmployeeKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<Employee> EntityMapper { get; }

	public UpdateEmployeeCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Employee> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
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

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new EmployeeKeyDto(entity.Id.Value);
	}
}