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
public record PartialUpdateBankNoteCommand(CurrencyKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties) : IRequest <BankNoteKeyDto?>;

public partial class PartialUpdateBankNoteCommandHandler: CommandBase<PartialUpdateBankNoteCommand, BankNote>, IRequestHandler <PartialUpdateBankNoteCommand, BankNoteKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<BankNote> EntityMapper { get; }

	public PartialUpdateBankNoteCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<BankNote> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<BankNoteKeyDto?> Handle(PartialUpdateBankNoteCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<BankNote,DatabaseNumber>("Id", request.UpdatedProperties["Id"]);
		var entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<BankNote>(), request.UpdatedProperties);
		
		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNoteKeyDto(entity.Id.Value);
	}
}