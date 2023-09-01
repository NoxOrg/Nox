﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record DeleteRefCurrencyToBankNotesCommand(CurrencyKeyDto EntityKeyDto, BankNotesKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class DeleteRefCurrencyToBankNotesCommandHandler: CommandBase<DeleteRefCurrencyToBankNotesCommand, Currency>, 
	IRequestHandler <DeleteRefCurrencyToBankNotesCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefCurrencyToBankNotesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefCurrencyToBankNotesCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<BankNotes,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.BankNotes.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.BankNotes.Remove(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}