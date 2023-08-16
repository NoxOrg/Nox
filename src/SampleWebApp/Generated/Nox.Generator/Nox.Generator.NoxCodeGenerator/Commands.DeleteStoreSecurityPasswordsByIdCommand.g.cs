// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Commands;

public record DeleteStoreSecurityPasswordsByIdCommand(System.String keyId) : IRequest<bool>;

public class DeleteStoreSecurityPasswordsByIdCommandHandler: CommandBase, IRequestHandler<DeleteStoreSecurityPasswordsByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteStoreSecurityPasswordsByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteStoreSecurityPasswordsByIdCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.keyId);

        var entity = await DbContext.StoreSecurityPasswords.FindAsync(keyId);
        if (entity is null || entity.IsDeleted.Value == true)
        {
            return false;
        }

        entity.Deleted();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}