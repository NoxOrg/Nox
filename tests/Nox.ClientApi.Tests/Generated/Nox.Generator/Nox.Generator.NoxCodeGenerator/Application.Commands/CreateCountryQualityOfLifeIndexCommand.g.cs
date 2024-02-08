﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public partial record CreateCountryQualityOfLifeIndexCommand(CountryQualityOfLifeIndexCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryQualityOfLifeIndexKeyDto>;

internal partial class CreateCountryQualityOfLifeIndexCommandHandler : CreateCountryQualityOfLifeIndexCommandHandlerBase
{
	public CreateCountryQualityOfLifeIndexCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryQualityOfLifeIndexCommandHandlerBase : CommandBase<CreateCountryQualityOfLifeIndexCommand,CountryQualityOfLifeIndexEntity>, IRequestHandler <CreateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> EntityFactory;

	protected CreateCountryQualityOfLifeIndexCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto> Handle(CreateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<ClientApi.Domain.CountryQualityOfLifeIndex>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CountryQualityOfLifeIndexKeyDto(entityToCreate.CountryId.Value, entityToCreate.Id.Value);
	}
}