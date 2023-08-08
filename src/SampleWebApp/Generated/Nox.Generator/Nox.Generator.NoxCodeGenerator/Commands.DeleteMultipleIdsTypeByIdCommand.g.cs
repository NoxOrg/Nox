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

public record DeleteMultipleIdsTypeByIdCommand(System.String key) : IRequest<bool>;

public class DeleteMultipleIdsTypeByIdCommandHandler: CommandBase, IRequestHandler<DeleteMultipleIdsTypeByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteMultipleIdsTypeByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteMultipleIdsTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var key = CreateNoxTypeForKey<MultipleIdsType,Text>("Id1", request.key);
        var entity = await DbContext.MultipleIdsTypes.FindAsync(key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}