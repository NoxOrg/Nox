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

internal partial class DeleteHolidayForCountryCommandHandler: CommandBase<DeleteHolidayForCountryCommand, Holiday>, IRequestHandler <DeleteHolidayForCountryCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteHolidayForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteHolidayForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.CountryCode2>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = CreateNoxTypeForKey<Holiday,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
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