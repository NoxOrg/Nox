﻿// Generated

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
using BankNoteEntity = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Commands;
public partial record DeleteBankNoteForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteBankNoteForCurrencyCommandHandler : DeleteBankNoteForCurrencyCommandHandlerBase
{
	public DeleteBankNoteForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteBankNoteForCurrencyCommandHandlerBase : CommandBase<DeleteBankNoteForCurrencyCommand, BankNoteEntity>, IRequestHandler <DeleteBankNoteForCurrencyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteBankNoteForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteBankNoteForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = Cryptocash.Domain.BankNoteMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CurrencyCommonBankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.CurrencyCommonBankNotes.Remove(entity);
		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}