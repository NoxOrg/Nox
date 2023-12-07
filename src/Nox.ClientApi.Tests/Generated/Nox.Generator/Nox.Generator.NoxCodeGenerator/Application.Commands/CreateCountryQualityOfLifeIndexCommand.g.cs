﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public partial record CreateCountryQualityOfLifeIndexCommand(CountryQualityOfLifeIndexCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryQualityOfLifeIndexKeyDto>;

internal partial class CreateCountryQualityOfLifeIndexCommandHandler : CreateCountryQualityOfLifeIndexCommandHandlerBase
{
	public CreateCountryQualityOfLifeIndexCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryQualityOfLifeIndexCommandHandlerBase : CommandBase<CreateCountryQualityOfLifeIndexCommand,CountryQualityOfLifeIndexEntity>, IRequestHandler <CreateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> EntityFactory;

	protected CreateCountryQualityOfLifeIndexCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto> Handle(CreateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.CountryQualityOfLifeIndices.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryQualityOfLifeIndexKeyDto(entityToCreate.CountryId.Value, entityToCreate.Id.Value);
	}
}