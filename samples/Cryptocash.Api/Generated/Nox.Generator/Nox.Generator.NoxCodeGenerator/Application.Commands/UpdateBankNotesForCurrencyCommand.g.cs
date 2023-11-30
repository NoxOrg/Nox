﻿
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
public partial record UpdateBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto, BankNoteUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <BankNoteKeyDto?>;

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

internal partial class UpdateBankNotesForCurrencyCommandHandlerBase : CommandBase<UpdateBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler <UpdateBankNotesForCurrencyCommand, BankNoteKeyDto?>
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

	public virtual async Task<BankNoteKeyDto?> Handle(UpdateBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.BankNotes).LoadAsync(cancellationToken);
		var ownedId = Cryptocash.Domain.BankNoteMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;


		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNoteKeyDto(entity.Id.Value);
	}

}