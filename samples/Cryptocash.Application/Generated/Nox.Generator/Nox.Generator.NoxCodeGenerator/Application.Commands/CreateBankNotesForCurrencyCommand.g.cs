﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using BankNoteEntity = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Commands;
public partial record CreateBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <BankNoteKeyDto>;

internal partial class CreateBankNotesForCurrencyCommandHandler : CreateBankNotesForCurrencyCommandHandlerBase
{
	public CreateBankNotesForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateBankNotesForCurrencyCommandHandlerBase : CommandBase<CreateBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler<CreateBankNotesForCurrencyCommand, BankNoteKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> _entityFactory;
	
	protected CreateBankNotesForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<BankNoteKeyDto?> Handle(CreateBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToBankNotes(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new BankNoteKeyDto(entity.Id.Value);
	}
}

public class CreateBankNotesForCurrencyValidator : AbstractValidator<CreateBankNotesForCurrencyCommand>
{
    public CreateBankNotesForCurrencyValidator()
    {
		RuleFor(x => x.EntityDto.Id).Null().WithMessage("Id must be null as it is auto generated.");
    }
}