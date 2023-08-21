// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;

namespace ClientApi.Application.Commands;

public record DeleteOwnedEntityByIdCommand(System.Int64 keyId) : IRequest<bool>;

public class DeleteOwnedEntityByIdCommandHandler: CommandBase, IRequestHandler<DeleteOwnedEntityByIdCommand, bool>
{
    public ClientApiDbContext DbContext { get; }

    public  DeleteOwnedEntityByIdCommandHandler(
        ClientApiDbContext dbContext,
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteOwnedEntityByIdCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<OwnedEntity,DatabaseNumber>("Id", request.keyId);

        var entity = await DbContext.OwnedEntities.FindAsync(keyId);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}