// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using StoreOwner = SampleWebApp.Domain.StoreOwner;

namespace SampleWebApp.Application.Commands;

public record DeleteStoreOwnerByIdCommand(System.String keyId) : IRequest<bool>;

public class DeleteStoreOwnerByIdCommandHandler: CommandBase<DeleteStoreOwnerByIdCommand,StoreOwner>, IRequestHandler<DeleteStoreOwnerByIdCommand, bool>
{
	public SampleWebAppDbContext DbContext { get; }

	public DeleteStoreOwnerByIdCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteStoreOwnerByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreOwner,Text>("Id", request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		OnCompleted(entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}