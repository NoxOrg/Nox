﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateEmployeePhoneNumberCommand(EmployeePhoneNumberCreateDto EntityDto) : IRequest<EmployeePhoneNumberKeyDto>;

public partial class CreateEmployeePhoneNumberCommandHandler: CommandBase<CreateEmployeePhoneNumberCommand>, IRequestHandler <CreateEmployeePhoneNumberCommand, EmployeePhoneNumberKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<EmployeePhoneNumberCreateDto,EmployeePhoneNumber> EntityFactory { get; }

	public CreateEmployeePhoneNumberCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<EmployeePhoneNumberCreateDto,EmployeePhoneNumber> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<EmployeePhoneNumberKeyDto> Handle(CreateEmployeePhoneNumberCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.EmployeePhoneNumbers.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EmployeePhoneNumberKeyDto(entityToCreate.Id.Value);
	}
}