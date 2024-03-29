﻿﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record UpdateCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, IEnumerable<CountryLocalNameUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<IEnumerable<CountryLocalNameKeyDto>>;

internal partial class UpdateCountryLocalNamesForCountryCommandHandler : UpdateCountryLocalNamesForCountryCommandHandlerBase
{
	public UpdateCountryLocalNamesForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryLocalNamesForCountryCommandHandlerBase : CommandCollectionBase<UpdateCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler <UpdateCountryLocalNamesForCountryCommand, IEnumerable<CountryLocalNameKeyDto>>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> _entityFactory;

	protected UpdateCountryLocalNamesForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<IEnumerable<CountryLocalNameKeyDto>> Handle(UpdateCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(),e => e.CountryLocalNames, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country",  "keyId");				
		List<CountryLocalNameEntity> entities = new(request.EntitiesDto.Count());
		foreach(var entityDto in request.EntitiesDto)
		{
			CountryLocalNameEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
				parentEntity.CreateCountryLocalNames(entity);
			}
			else
			{
				var ownedId = Dto.CountryLocalNameMetadata.CreateId(entityDto.Id.NonNullValue<System.Int64>());
				entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
				{
					throw new EntityNotFoundException("CountryLocalName",  $"ownedId");
				}
				else
				{
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
				}
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entities!);
		await _repository.SaveChangesAsync();

		return entities.Select(entity => new CountryLocalNameKeyDto(entity.Id.Value));
	}
	
	private async Task<CountryLocalNameEntity> CreateEntityAsync(CountryLocalNameUpsertDto upsertDto, CountryEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateCountryLocalNames(entity);
		return entity;
	}
}

public class UpdateCountryLocalNamesForCountryCommandValidator : AbstractValidator<UpdateCountryLocalNamesForCountryCommand>
{
    public UpdateCountryLocalNamesForCountryCommandValidator()
    {
    }
}