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

public record DeleteClientNuidByIdCommand(System.UInt32 keyId) : IRequest<bool>;

public class DeleteClientNuidByIdCommandHandler: CommandBase, IRequestHandler<DeleteClientNuidByIdCommand, bool>
{
    public ClientApiDbContext DbContext { get; }

    public  DeleteClientNuidByIdCommandHandler(
        ClientApiDbContext dbContext,
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteClientNuidByIdCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<ClientNuid,Nuid>("Id", request.keyId);

        var entity = await DbContext.ClientNuids.FindAsync(keyId);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}