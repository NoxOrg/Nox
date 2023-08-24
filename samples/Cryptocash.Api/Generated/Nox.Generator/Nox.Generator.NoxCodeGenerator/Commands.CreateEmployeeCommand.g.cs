﻿﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateEmployeeCommand(EmployeeCreateDto EntityDto) : IRequest<EmployeeKeyDto>;

public partial class CreateEmployeeCommandHandler: CommandBase<CreateEmployeeCommand>, IRequestHandler <CreateEmployeeCommand, EmployeeKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<EmployeeCreateDto,Employee> EntityFactory { get; }

	public CreateEmployeeCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmployeeCreateDto,Employee> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<EmployeeKeyDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.Employees.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}