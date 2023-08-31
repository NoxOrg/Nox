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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateRefCurrencyToCurrencyBankNotesCommand(CurrencyKeyDto EntityKeyDto, CurrencyBankNotesKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCurrencyToCurrencyBankNotesCommandHandler: CommandBase<CreateRefCurrencyToCurrencyBankNotesCommand, Currency>, 
	IRequestHandler <CreateRefCurrencyToCurrencyBankNotesCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefCurrencyToCurrencyBankNotesCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefCurrencyToCurrencyBankNotesCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CurrencyBankNotes,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.CurrencyBankNotes.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}		
		entity.CurrencyBankNotes.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}