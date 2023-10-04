﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public record CreateCountryQualityOfLifeIndexCommand(CountryQualityOfLifeIndexCreateDto EntityDto) : IRequest<CountryQualityOfLifeIndexKeyDto>;

internal partial class CreateCountryQualityOfLifeIndexCommandHandler : CreateCountryQualityOfLifeIndexCommandHandlerBase
{
	public CreateCountryQualityOfLifeIndexCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryQualityOfLifeIndexCommandHandlerBase : CommandBase<CreateCountryQualityOfLifeIndexCommand,CountryQualityOfLifeIndexEntity>, IRequestHandler <CreateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> _entityFactory;

	public CreateCountryQualityOfLifeIndexCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto> Handle(CreateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		OnCompleted(request, entityToCreate);
		_dbContext.CountryQualityOfLifeIndices.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CountryQualityOfLifeIndexKeyDto(entityToCreate.CountryId.Value, entityToCreate.Id.Value);
	}
}