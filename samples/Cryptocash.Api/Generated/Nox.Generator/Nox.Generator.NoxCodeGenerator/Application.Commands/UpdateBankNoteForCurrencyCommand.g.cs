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
public partial record UpdateBankNoteForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto, BankNoteUpdateDto EntityDto, System.Guid? Etag) : IRequest <BankNoteKeyDto?>;

internal partial class UpdateBankNoteForCurrencyCommandHandler : UpdateBankNoteForCurrencyCommandHandlerBase
{
	public UpdateBankNoteForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteCreateDto, BankNoteUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateBankNoteForCurrencyCommandHandlerBase : CommandBase<UpdateBankNoteForCurrencyCommand, BankNoteEntity>, IRequestHandler <UpdateBankNoteForCurrencyCommand, BankNoteKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<BankNoteEntity, BankNoteCreateDto, BankNoteUpdateDto> _entityFactory;

	public UpdateBankNoteForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteCreateDto, BankNoteUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<BankNoteKeyDto?> Handle(UpdateBankNoteForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = Cryptocash.Domain.BankNoteMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CurrencyCommonBankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNoteKeyDto(entity.Id.Value);
	}
}