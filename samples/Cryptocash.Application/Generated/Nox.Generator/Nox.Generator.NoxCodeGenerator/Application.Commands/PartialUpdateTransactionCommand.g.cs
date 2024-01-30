// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateTransactionCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TransactionKeyDto>;

internal partial class PartialUpdateTransactionCommandHandler : PartialUpdateTransactionCommandHandlerBase
{
	public PartialUpdateTransactionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTransactionCommandHandlerBase : CommandBase<PartialUpdateTransactionCommand, TransactionEntity>, IRequestHandler<PartialUpdateTransactionCommand, TransactionKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTransactionCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TransactionKeyDto> Handle(PartialUpdateTransactionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TransactionMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Transaction>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TransactionKeyDto(entity.Id.Value);
	}
}