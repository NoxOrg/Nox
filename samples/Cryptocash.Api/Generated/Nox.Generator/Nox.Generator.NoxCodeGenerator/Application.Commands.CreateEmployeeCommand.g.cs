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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateEmployeeCommand(EmployeeCreateDto EntityDto) : IRequest<EmployeeKeyDto>;

public partial class CreateEmployeeCommandHandler: CommandBase<CreateEmployeeCommand,Employee>, IRequestHandler <CreateEmployeeCommand, EmployeeKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<EmployeeCreateDto,Employee> EntityFactory { get; }	
	public IEntityFactory<EmployeePhoneNumberDto,EmployeePhoneNumber> EmployeePhoneNumberEntityFactory { get; }

	public CreateEmployeeCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,	
		IEntityFactory<EmployeePhoneNumberDto,EmployeePhoneNumber> entityFactoryEmployeePhoneNumber,
		IEntityFactory<EmployeeCreateDto,Employee> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;	
		EmployeePhoneNumberEntityFactory = entityFactoryEmployeePhoneNumber;
	}

	public async Task<EmployeeKeyDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var ownedEntity in request.EntityDto.EmployeePhoneNumbers)
		{
			entityToCreate.EmployeePhoneNumbers.Add(
				EmployeePhoneNumberEntityFactory.CreateEntity(ownedEntity)
				);
		}
	
		OnCompleted(entityToCreate);
		DbContext.Employees.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}