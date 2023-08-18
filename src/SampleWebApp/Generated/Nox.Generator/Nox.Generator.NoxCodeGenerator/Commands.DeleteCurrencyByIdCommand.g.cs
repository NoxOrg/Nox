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

public record DeleteCurrencyByIdCommand(System.UInt32 keyId) : IRequest<bool>;

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
        var keyId = CreateNoxTypeForKey<Currency,Nuid>("Id", request.keyId);

        var entity = await DbContext.Currencies.FindAsync(keyId);
        if (entity is null || entity.IsDeleted.Value == true)
        {
            return false;
        }
        //entity.Deleted();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}