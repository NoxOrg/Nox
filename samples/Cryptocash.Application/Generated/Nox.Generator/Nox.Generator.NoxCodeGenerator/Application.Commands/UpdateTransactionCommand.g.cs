﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public partial record UpdateTransactionCommand(System.Guid keyId, TransactionUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TransactionKeyDto>;

internal partial class UpdateTransactionCommandHandler : UpdateTransactionCommandHandlerBase
{
	public UpdateTransactionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTransactionCommandHandlerBase : CommandBase<UpdateTransactionCommand, TransactionEntity>, IRequestHandler<UpdateTransactionCommand, TransactionKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> EntityFactory { get; }
	protected UpdateTransactionCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TransactionKeyDto> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Cryptocash.Domain.Transaction>()
            .Where(x => x.Id == Dto.TransactionMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TransactionKeyDto(entity.Id.Value);
	}
}