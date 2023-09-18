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
public record UpdateBankNoteForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteKeyDto EntityKeyDto, BankNoteUpdateDto EntityDto, System.Guid? Etag) : IRequest <BankNoteKeyDto?>;

public partial class UpdateBankNoteForCurrencyCommandHandler: UpdateBankNoteForCurrencyCommandHandlerBase
{
	public UpdateBankNoteForCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<BankNote> entityMapper): base(dbContext ,noxSolution, serviceProvider, entityMapper)
	{
	}
}
public abstract class UpdateBankNoteForCurrencyCommandHandlerBase: CommandBase<UpdateBankNoteForCurrencyCommand, BankNote>, IRequestHandler <UpdateBankNoteForCurrencyCommand, BankNoteKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<BankNote> EntityMapper { get; }

	public UpdateBankNoteForCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<BankNote> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public virtual async Task<BankNoteKeyDto?> Handle(UpdateBankNoteForCurrencyCommand request, CancellationToken cancellationToken)
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

		EntityMapper.MapToEntity(entity, GetEntityDefinition<BankNote>(), request.EntityDto);
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