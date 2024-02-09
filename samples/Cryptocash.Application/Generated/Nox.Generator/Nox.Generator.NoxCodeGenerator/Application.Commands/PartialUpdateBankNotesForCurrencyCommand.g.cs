﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using BankNoteEntity = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Commands;
public partial record PartialUpdateBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <BankNoteKeyDto>;
internal partial class PartialUpdateBankNotesForCurrencyCommandHandler: PartialUpdateBankNotesForCurrencyCommandHandlerBase
{
	public PartialUpdateBankNotesForCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateBankNotesForCurrencyCommandHandlerBase: CommandBase<PartialUpdateBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler <PartialUpdateBankNotesForCurrencyCommand, BankNoteKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> EntityFactory;
	
	protected PartialUpdateBankNotesForCurrencyCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<BankNoteKeyDto> Handle(PartialUpdateBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<Cryptocash.Domain.Currency>(keys.ToArray(),e => e.BankNotes, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  "keyId");
		}
		var ownedId = Dto.BankNoteMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency.BankNotes", $"ownedId");
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new BankNoteKeyDto(entity.Id.Value);
	}
}