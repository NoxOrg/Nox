﻿﻿﻿// Generated

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

public partial record DeleteAllBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllBankNotesForCurrencyCommandHandler : DeleteAllBankNotesForCurrencyCommandHandlerBase
{
	public DeleteAllBankNotesForCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllBankNotesForCurrencyCommandHandlerBase : CommandCollectionBase<DeleteAllBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler <DeleteAllBankNotesForCurrencyCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllBankNotesForCurrencyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId));
		
		
		var parentEntity = await Repository.FindAndIncludeAsync<Cryptocash.Domain.Currency>(keys.ToArray(), p => p.BankNotes, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Currency", "parentKeyId");
		
		if(parentEntity.BankNotes is not null)
		{
			Repository.DeleteOwned(parentEntity.BankNotes!);
			await OnCompletedAsync(request, parentEntity.BankNotes!);
		}
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}