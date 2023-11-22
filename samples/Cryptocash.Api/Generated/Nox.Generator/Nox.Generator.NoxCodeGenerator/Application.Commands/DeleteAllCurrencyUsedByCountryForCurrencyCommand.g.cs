﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllCurrencyUsedByCountryForCurrencyCommand(CurrencyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllCurrencyUsedByCountryForCurrencyCommandHandler : DeleteAllCurrencyUsedByCountryForCurrencyCommandHandlerBase
{
	public DeleteAllCurrencyUsedByCountryForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllCurrencyUsedByCountryForCurrencyCommandHandlerBase : CommandBase<DeleteAllCurrencyUsedByCountryForCurrencyCommand, CountryEntity>, IRequestHandler <DeleteAllCurrencyUsedByCountryForCurrencyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllCurrencyUsedByCountryForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllCurrencyUsedByCountryForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.Currencies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.Countries;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.Countries.Remove(relatedEntity);
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}