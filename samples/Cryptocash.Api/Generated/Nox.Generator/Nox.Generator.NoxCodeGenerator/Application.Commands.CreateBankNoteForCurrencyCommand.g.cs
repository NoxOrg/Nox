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
using BankNote = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Commands;
public record CreateBankNoteForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteCreateDto EntityDto, System.Guid? Etag) : IRequest <BankNoteKeyDto?>;

public partial class CreateBankNoteForCurrencyCommandHandler: CreateBankNoteForCurrencyCommandHandlerBase
{
	public CreateBankNoteForCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<BankNote,BankNoteCreateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution, entityFactory, serviceProvider)
	{
	}
}
public abstract class CreateBankNoteForCurrencyCommandHandlerBase: CommandBase<CreateBankNoteForCurrencyCommand, BankNote>, IRequestHandler<CreateBankNoteForCurrencyCommand, BankNoteKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<BankNote,BankNoteCreateDto> _entityFactory;

	public CreateBankNoteForCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<BankNote,BankNoteCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public virtual  async Task<BankNoteKeyDto?> Handle(CreateBankNoteForCurrencyCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nox.Types.CurrencyCode3>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CurrencyCommonBankNotes.Add(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNoteKeyDto(entity.Id.Value);
	}
}