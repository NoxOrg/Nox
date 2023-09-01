﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using BankNotes = Cryptocash.Domain.BankNotes;

namespace Cryptocash.Application.Commands;

public record PartialUpdateBankNotesCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <BankNotesKeyDto?>;

public class PartialUpdateBankNotesCommandHandler: CommandBase<PartialUpdateBankNotesCommand, BankNotes>, IRequestHandler<PartialUpdateBankNotesCommand, BankNotesKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<BankNotes> EntityMapper { get; }

	public PartialUpdateBankNotesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<BankNotes> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<BankNotesKeyDto?> Handle(PartialUpdateBankNotesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<BankNotes,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.BankNotes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<BankNotes>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new BankNotesKeyDto(entity.Id.Value);
	}
}