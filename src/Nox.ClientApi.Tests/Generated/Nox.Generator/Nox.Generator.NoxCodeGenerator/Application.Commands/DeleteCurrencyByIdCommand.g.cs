// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Commands;

public partial record DeleteCurrencyByIdCommand(IEnumerable<CurrencyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCurrencyByIdCommandHandler : DeleteCurrencyByIdCommandHandlerBase
{
	public DeleteCurrencyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCurrencyByIdCommandHandlerBase : CommandBase<DeleteCurrencyByIdCommand, CurrencyEntity>, IRequestHandler<DeleteCurrencyByIdCommand, bool>
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
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = ClientApi.Domain.CurrencyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Currencies.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new CurrencyEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}