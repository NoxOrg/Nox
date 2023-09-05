﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Employee = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public record PartialUpdateEmployeeCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <EmployeeKeyDto?>;

public class PartialUpdateEmployeeCommandHandler: CommandBase<PartialUpdateEmployeeCommand, Employee>, IRequestHandler<PartialUpdateEmployeeCommand, EmployeeKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Employee> EntityMapper { get; }

	public PartialUpdateEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Employee> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<EmployeeKeyDto?> Handle(PartialUpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Employee>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entity.Id.Value);
	}
}