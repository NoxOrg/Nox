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
public record DeleteBankNoteCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto) : IRequest <bool>;

public partial class DeleteBankNoteCommandHandler: CommandBase<DeleteBankNoteCommand, BankNote>, IRequestHandler <DeleteBankNoteCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteBankNoteCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteBankNoteCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = CreateNoxTypeForKey<BankNote,DatabaseNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}

		parentEntity.BankNotes.Remove(entity);
		
		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Deleted;
		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}