﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryTimeZoneEntity = ClientApi.Domain.CountryTimeZone;

namespace ClientApi.Application.Commands;
public partial record DeleteCountryTimeZonesForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteCountryTimeZonesForCountryCommandHandler : DeleteCountryTimeZonesForCountryCommandHandlerBase
{
	public DeleteCountryTimeZonesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteCountryTimeZonesForCountryCommandHandlerBase : CommandBase<DeleteCountryTimeZonesForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <DeleteCountryTimeZonesForCountryCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountryTimeZonesForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryTimeZonesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(parentEntity).Collection(p => p.CountryTimeZones).LoadAsync(cancellationToken);
		var ownedId = ClientApi.Domain.CountryTimeZoneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryTimeZones.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryTimeZone.CountryTimeZones",  $"{ownedId.ToString()}");
		}
		parentEntity.CountryTimeZones.Remove(entity);
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);

		return true;
	}
}