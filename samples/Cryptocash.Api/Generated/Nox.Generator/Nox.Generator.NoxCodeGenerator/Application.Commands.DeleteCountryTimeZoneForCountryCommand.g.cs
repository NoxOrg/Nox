﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryTimeZoneEntity = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Commands;
public record DeleteCountryTimeZoneForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteCountryTimeZoneForCountryCommandHandler : DeleteCountryTimeZoneForCountryCommandHandlerBase
{
	public DeleteCountryTimeZoneForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteCountryTimeZoneForCountryCommandHandlerBase : CommandBase<DeleteCountryTimeZoneForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <DeleteCountryTimeZoneForCountryCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteCountryTimeZoneForCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryTimeZoneForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = Cryptocash.Domain.CountryTimeZoneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryOwnedTimeZones.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.CountryOwnedTimeZones.Remove(entity);
		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}