﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto>;
internal partial class PartialUpdateCountryLocalNamesForCountryCommandHandler: PartialUpdateCountryLocalNamesForCountryCommandHandlerBase
{
	public PartialUpdateCountryLocalNamesForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryLocalNamesForCountryCommandHandlerBase: CommandBase<PartialUpdateCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler <PartialUpdateCountryLocalNamesForCountryCommand, CountryLocalNameKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> EntityFactory;
	
	protected PartialUpdateCountryLocalNamesForCountryCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryLocalNameKeyDto> Handle(PartialUpdateCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<Country>(keys.ToArray(),e => e.CountryLocalNames, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  "keyId");
		}
		var ownedId = Dto.CountryLocalNameMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country.CountryLocalNames", $"ownedId");
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}