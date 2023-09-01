﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Employee = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;
public record CreateEmployeeCommand(EmployeeCreateDto EntityDto) : IRequest<EmployeeKeyDto>;

public partial class CreateEmployeeCommandHandler: CommandBase<CreateEmployeeCommand,Employee>, IRequestHandler <CreateEmployeeCommand, EmployeeKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<EmployeeCreateDto,Employee> EntityFactory { get; }

	public CreateEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmployeeCreateDto,Employee> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<EmployeeKeyDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.Employees.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}