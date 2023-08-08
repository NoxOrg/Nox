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

public record DeleteStoreSecurityPasswordsByIdCommand(System.String key) : IRequest<bool>;

public class DeleteStoreSecurityPasswordsByIdCommandHandler: CommandBase<DeleteStoreSecurityPasswordsByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteStoreSecurityPasswordsByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async override Task<bool> Handle(DeleteStoreSecurityPasswordsByIdCommand request, CancellationToken cancellationToken)
    {
        var key = CreateNoxTypeForKey<StoreSecurityPasswords,Text>("Id", request.key);
        var entity = await DbContext.StoreSecurityPasswords.FindAsync(key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}