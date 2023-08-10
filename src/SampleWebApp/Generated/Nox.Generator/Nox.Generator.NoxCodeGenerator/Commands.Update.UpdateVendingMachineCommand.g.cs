// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;


namespace SampleWebApp.Application.Commands;

public record UpdateVendingMachineCommand(System.UInt64 key, VendingMachineUpdateDto EntityDto) : IRequest<bool>;

public class UpdateVendingMachineCommandHandler: CommandBase, IRequestHandler<UpdateVendingMachineCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<VendingMachine> EntityMapper { get; }

    public  UpdateVendingMachineCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<VendingMachine> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(UpdateVendingMachineCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.VendingMachines.FindAsync(CreateNoxTypeForKey<VendingMachine,DatabaseNumber>("Id", request.key));
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<VendingMachine>(), request.EntityDto);
        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}