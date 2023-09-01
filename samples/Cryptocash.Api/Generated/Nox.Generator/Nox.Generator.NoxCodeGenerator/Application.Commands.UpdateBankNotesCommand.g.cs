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
using BankNotes = Cryptocash.Domain.BankNotes;

namespace Cryptocash.Application.Commands;

public record UpdateBankNotesCommand(System.Int64 keyId, BankNotesUpdateDto EntityDto) : IRequest<BankNotesKeyDto?>;

public class UpdateBankNotesCommandHandler: CommandBase<UpdateBankNotesCommand, BankNotes>, IRequestHandler<UpdateBankNotesCommand, BankNotesKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<BankNotes> EntityMapper { get; }

	public UpdateBankNotesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<BankNotes> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<BankNotesKeyDto?> Handle(UpdateBankNotesCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<BankNotes,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.BankNotes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<BankNotes>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNotesKeyDto(entity.Id.Value);
	}
}