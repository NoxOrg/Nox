﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public partial record UpdateCountryQualityOfLifeIndexCommand(System.Int64 keyCountryId, System.Int64 keyId, CountryQualityOfLifeIndexUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryQualityOfLifeIndexKeyDto>;

internal partial class UpdateCountryQualityOfLifeIndexCommandHandler : UpdateCountryQualityOfLifeIndexCommandHandlerBase
{
	public UpdateCountryQualityOfLifeIndexCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryQualityOfLifeIndexCommandHandlerBase : CommandBase<UpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexEntity>, IRequestHandler<UpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> EntityFactory { get; }
	protected UpdateCountryQualityOfLifeIndexCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto> Handle(UpdateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<CountryQualityOfLifeIndex>()
            .Where(x => x.CountryId == Dto.CountryQualityOfLifeIndexMetadata.CreateCountryId(request.keyCountryId))
            .Where(x => x.Id == Dto.CountryQualityOfLifeIndexMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQualityOfLifeIndex",  "keyCountryId, keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new CountryQualityOfLifeIndexKeyDto(entity.CountryId.Value, entity.Id.Value);
	}
}