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

public record DeleteAllNoxTypeByIdCommand(System.UInt64 key) : IRequest<bool>;

public class DeleteAllNoxTypeByIdCommandHandler: CommandBase, IRequestHandler<DeleteAllNoxTypeByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteAllNoxTypeByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteAllNoxTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var key = CreateNoxTypeForKey<AllNoxType,DatabaseNumber>("Id", request.key);
        var entity = await DbContext.AllNoxTypes.FindAsync(key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}