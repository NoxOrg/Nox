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
public partial record PartialUpdateBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <BankNoteKeyDto?>;
internal partial class PartialUpdateBankNotesForCurrencyCommandHandler: PartialUpdateBankNotesForCurrencyCommandHandlerBase
{
	public PartialUpdateBankNotesForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateBankNotesForCurrencyCommandHandlerBase: CommandBase<PartialUpdateBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler <PartialUpdateBankNotesForCurrencyCommand, BankNoteKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> EntityFactory { get; }

	public PartialUpdateBankNotesForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<BankNoteKeyDto?> Handle(PartialUpdateBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.BankNotes).LoadAsync(cancellationToken);
		var ownedId = Cryptocash.Domain.BankNoteMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNoteKeyDto(entity.Id.Value);
	}
}