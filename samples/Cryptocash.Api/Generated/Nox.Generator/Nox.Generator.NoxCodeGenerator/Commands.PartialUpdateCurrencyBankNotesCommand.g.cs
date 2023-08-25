﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCurrencyBankNotesCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CurrencyBankNotesKeyDto?>;

public class PartialUpdateCurrencyBankNotesCommandHandler: CommandBase<PartialUpdateCurrencyBankNotesCommand>, IRequestHandler<PartialUpdateCurrencyBankNotesCommand, CurrencyBankNotesKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<CurrencyBankNotes> EntityMapper { get; }

	public PartialUpdateCurrencyBankNotesCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CurrencyBankNotes> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CurrencyBankNotesKeyDto?> Handle(PartialUpdateCurrencyBankNotesCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<CurrencyBankNotes,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CurrencyBankNotes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CurrencyBankNotes>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CurrencyBankNotesKeyDto(entity.Id.Value);
	}
}