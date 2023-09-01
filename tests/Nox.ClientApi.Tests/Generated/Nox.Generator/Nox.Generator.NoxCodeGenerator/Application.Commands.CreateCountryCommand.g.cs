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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Country = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;
public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<CountryKeyDto>;

public partial class CreateCountryCommandHandler: CommandBase<CreateCountryCommand,Country>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<CountryCreateDto,Country> EntityFactory { get; }	
	public IEntityFactory<CountryLocalNameDto,CountryLocalName> CountryLocalNameEntityFactory { get; }

	public CreateCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,	
		IEntityFactory<CountryLocalNameDto,CountryLocalName> entityFactoryCountryLocalName,
		IEntityFactory<CountryCreateDto,Country> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;	
		CountryLocalNameEntityFactory = entityFactoryCountryLocalName;
	}

	public async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var ownedEntity in request.EntityDto.CountryLocalNames)
		{
			entityToCreate.CountryLocalNames.Add(
				CountryLocalNameEntityFactory.CreateEntity(ownedEntity)
				);
		}
	
		OnCompleted(entityToCreate);
		DbContext.Countries.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}