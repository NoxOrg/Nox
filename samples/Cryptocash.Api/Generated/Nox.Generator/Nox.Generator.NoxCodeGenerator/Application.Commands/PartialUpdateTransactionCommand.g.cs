// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateTransactionCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TransactionKeyDto>;

internal partial class PartialUpdateTransactionCommandHandler : PartialUpdateTransactionCommandHandlerBase
{
	public PartialUpdateTransactionCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTransactionCommandHandlerBase : CommandBase<PartialUpdateTransactionCommand, TransactionEntity>, IRequestHandler<PartialUpdateTransactionCommand, TransactionKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> EntityFactory { get; }

	public PartialUpdateTransactionCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TransactionKeyDto> Handle(PartialUpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.keyId);

		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TransactionKeyDto(entity.Id.Value);
	}
}