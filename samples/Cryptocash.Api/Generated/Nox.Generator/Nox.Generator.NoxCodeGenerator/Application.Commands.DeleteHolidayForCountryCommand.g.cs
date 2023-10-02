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

namespace Cryptocash.Application.Commands;
public record DeleteHolidayForCountryCommand(CountryKeyDto ParentKeyDto, HolidayKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteHolidayForCountryCommandHandler : DeleteHolidayForCountryCommandHandlerBase
{
	public DeleteHolidayForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteHolidayForCountryCommandHandlerBase : CommandBase<DeleteHolidayForCountryCommand, Holiday>, IRequestHandler <DeleteHolidayForCountryCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteHolidayForCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution): base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteHolidayForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = Cryptocash.Domain.HolidayMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryOwnedHolidays.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.CountryOwnedHolidays.Remove(entity);
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