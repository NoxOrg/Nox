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
public record PartialUpdateBankNoteForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <BankNoteKeyDto?>;
internal partial class PartialUpdateBankNoteForCurrencyCommandHandler: PartialUpdateBankNoteForCurrencyCommandHandlerBase
{
	public PartialUpdateBankNoteForCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto> entityFactory) : base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal abstract class PartialUpdateBankNoteForCurrencyCommandHandlerBase: CommandBase<PartialUpdateBankNoteForCurrencyCommand, BankNote>, IRequestHandler <PartialUpdateBankNoteForCurrencyCommand, BankNoteKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto> EntityFactory { get; }

	public PartialUpdateBankNoteForCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<BankNoteKeyDto?> Handle(PartialUpdateBankNoteForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nox.Types.CurrencyCode3>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<BankNote,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CurrencyCommonBankNotes.SingleOrDefault(x => x.Id == ownedId);	
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNoteKeyDto(entity.Id.Value);
	}
}