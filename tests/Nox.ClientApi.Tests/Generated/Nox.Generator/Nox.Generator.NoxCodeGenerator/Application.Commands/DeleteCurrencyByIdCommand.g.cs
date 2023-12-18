// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Commands;

public partial record DeleteCurrencyByIdCommand(IEnumerable<CurrencyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCurrencyByIdCommandHandler : DeleteCurrencyByIdCommandHandlerBase
{
	public DeleteCurrencyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCurrencyByIdCommandHandlerBase : CommandCollectionBase<DeleteCurrencyByIdCommand, CurrencyEntity>, IRequestHandler<DeleteCurrencyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCurrencyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCurrencyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CurrencyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = ClientApi.Domain.CurrencyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Currencies.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Currency",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}