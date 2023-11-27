﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using BankNoteEntity = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Commands;

public partial record UpdateBankNotesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, BankNoteUpsertDto EntityDto, System.Guid? Etag) : IRequest <BankNoteKeyDto?>;

internal partial class UpdateBankNotesForCurrencyCommandHandler : UpdateBankNotesForCurrencyCommandHandlerBase
{
	public UpdateBankNotesForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateBankNotesForCurrencyCommandHandlerBase : CommandBase<UpdateBankNotesForCurrencyCommand, BankNoteEntity>, IRequestHandler <UpdateBankNotesForCurrencyCommand, BankNoteKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> _entityFactory;

	public UpdateBankNotesForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<BankNoteKeyDto?> Handle(UpdateBankNotesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.BankNotes).LoadAsync(cancellationToken);
		var ownedId = Cryptocash.Domain.BankNoteMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
		var entity = parentEntity.BankNotes.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new BankNoteKeyDto(entity.Id.Value);
	}
}

public class UpdateBankNotesForCurrencyValidator : AbstractValidator<UpdateBankNotesForCurrencyCommand>
{
    public UpdateBankNotesForCurrencyValidator(ILogger<UpdateBankNotesForCurrencyCommand> logger)
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}