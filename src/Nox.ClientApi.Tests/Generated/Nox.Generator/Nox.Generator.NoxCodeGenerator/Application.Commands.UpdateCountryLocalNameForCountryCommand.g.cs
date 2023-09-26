﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;
public record UpdateCountryLocalNameForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto, CountryLocalNameUpdateDto EntityDto, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto?>;

internal partial class UpdateCountryLocalNameForCountryCommandHandler : UpdateCountryLocalNameForCountryCommandHandlerBase
{
	public UpdateCountryLocalNameForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory)
		: base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

internal partial class UpdateCountryLocalNameForCountryCommandHandlerBase : CommandBase<UpdateCountryLocalNameForCountryCommand, CountryLocalName>, IRequestHandler <UpdateCountryLocalNameForCountryCommand, CountryLocalNameKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> _entityFactory;

	public UpdateCountryLocalNameForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryLocalNameKeyDto?> Handle(UpdateCountryLocalNameForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<CountryLocalName,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryShortNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}