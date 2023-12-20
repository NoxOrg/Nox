﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using BankNoteEntity = Cryptocash.Domain.BankNote;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public partial record UpdateBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <BankNoteKeyDto>;

internal partial class UpdateBankNotesForCurrencyCommandHandler : UpdateBankNotesForCurrencyCommandHandlerBase
{
	public UpdateBankNotesForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateBankNotesForCurrencyCommandHandlerBase : CommandBase<UpdateBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler <UpdateBankNotesForCurrencyCommand, BankNoteKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> _entityFactory;

	protected UpdateBankNotesForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<BankNoteKeyDto> Handle(UpdateBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.BankNotes).LoadAsync(cancellationToken);
		
		BankNoteEntity? entity;
		if(request.EntityDto.Id is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity);
		}
		else
		{
			var ownedId = Cryptocash.Domain.BankNoteMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
			entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
			if (entity is null)
				throw new EntityNotFoundException("BankNote",  $"{ownedId.ToString()}");
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;


		var result = await _dbContext.SaveChangesAsync();

		return new BankNoteKeyDto(entity.Id.Value);
	}
	
	private async Task<BankNoteEntity> CreateEntityAsync(BankNoteUpsertDto upsertDto, CurrencyEntity parent)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto);
		parent.CreateRefToBankNotes(entity);
		return entity;
	}
}

public class UpdateBankNotesForCurrencyValidator : AbstractValidator<UpdateBankNotesForCurrencyCommand>
{
    public UpdateBankNotesForCurrencyValidator()
    {
    }
}