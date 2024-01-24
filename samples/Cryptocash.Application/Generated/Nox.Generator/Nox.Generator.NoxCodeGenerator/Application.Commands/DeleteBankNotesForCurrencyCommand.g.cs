﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using BankNoteEntity = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Commands;
public partial record DeleteBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteBankNotesForCurrencyCommandHandler : DeleteBankNotesForCurrencyCommandHandlerBase
{
	public DeleteBankNotesForCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteBankNotesForCurrencyCommandHandlerBase : CommandBase<DeleteBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler <DeleteBankNotesForCurrencyCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteBankNotesForCurrencyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<Currency>(keys.ToArray(), p => p.BankNotes, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  "keyId");
		}
		var ownedId = Dto.BankNoteMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("BankNote.BankNotes",  $"ownedId");
		}
		parentEntity.BankNotes.Remove(entity);
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}