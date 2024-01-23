// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public partial record DeleteTransactionByIdCommand(IEnumerable<TransactionKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTransactionByIdCommandHandler : DeleteTransactionByIdCommandHandlerBase
{
	public DeleteTransactionByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTransactionByIdCommandHandlerBase : CommandCollectionBase<DeleteTransactionByIdCommand, TransactionEntity>, IRequestHandler<DeleteTransactionByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTransactionByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTransactionByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TransactionEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TransactionMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<Transaction>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Transaction",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TransactionEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}