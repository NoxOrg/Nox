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

public record DeleteVendingMachineByIdCommand(System.UInt64 key) : IRequest<bool>;

public class DeleteVendingMachineByIdCommandHandler: CommandBase, IRequestHandler<DeleteVendingMachineByIdCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }

    public  DeleteVendingMachineByIdCommandHandler(
        SampleWebAppDbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(DeleteVendingMachineByIdCommand request, CancellationToken cancellationToken)
    {
        var key = CreateNoxTypeForKey<VendingMachine,DatabaseNumber>("Id", request.key);
        var entity = await DbContext.VendingMachines.FindAsync(key);
        if (entity == null || entity.Deleted == true)
        {
            return false;
        }

        entity.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}