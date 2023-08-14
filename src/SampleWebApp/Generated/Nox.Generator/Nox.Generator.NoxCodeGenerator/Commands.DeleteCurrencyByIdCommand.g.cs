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

public record DeleteCurrencyByIdCommand(System.UInt32 key) : IRequest<bool>;

public class DeleteCurrencyByIdCommandHandler: CommandBase, IRequestHandler<DeleteCurrencyByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteCurrencyByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteCurrencyByIdCommand request, CancellationToken cancellationToken)
    {
        var key = CreateNoxTypeForKey<Currency,Nuid>("Id", request.key);
        var entity = await DbContext.Currencies.FindAsync(key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}