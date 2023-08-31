// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using AllNoxType = SampleWebApp.Domain.AllNoxType;

namespace SampleWebApp.Application.Commands;

public record DeleteAllNoxTypeByIdCommand(System.Int64 keyId, System.String keyTextId) : IRequest<bool>;

public class DeleteAllNoxTypeByIdCommandHandler: CommandBase<DeleteAllNoxTypeByIdCommand,AllNoxType>, IRequestHandler<DeleteAllNoxTypeByIdCommand, bool>
{
	public SampleWebAppDbContext DbContext { get; }

	public DeleteAllNoxTypeByIdCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteAllNoxTypeByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<AllNoxType,DatabaseNumber>("Id", request.keyId);
		var keyTextId = CreateNoxTypeForKey<AllNoxType,Text>("TextId", request.keyTextId);

		var entity = await DbContext.AllNoxTypes.FindAsync(keyId, keyTextId);
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