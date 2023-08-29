﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdateCurrencyBankNotesCommand(System.Int64 keyId, CurrencyBankNotesUpdateDto EntityDto) : IRequest<CurrencyBankNotesKeyDto?>;

public class UpdateCurrencyBankNotesCommandHandler: CommandBase<UpdateCurrencyBankNotesCommand, CurrencyBankNotes>, IRequestHandler<UpdateCurrencyBankNotesCommand, CurrencyBankNotesKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<CurrencyBankNotes> EntityMapper { get; }

	public UpdateCurrencyBankNotesCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CurrencyBankNotes> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CurrencyBankNotesKeyDto?> Handle(UpdateCurrencyBankNotesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CurrencyBankNotes,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.CurrencyBankNotes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<CurrencyBankNotes>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CurrencyBankNotesKeyDto(entity.Id.Value);
	}
}