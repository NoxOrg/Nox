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

public record UpdateStoreCommand(System.String key, StoreDto EntityDto) : IRequest<bool>;

public class UpdateStoreCommandHandler: CommandBase, IRequestHandler<UpdateStoreCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    

    public  UpdateStoreCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task<bool> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.Stores.FindAsync(CreateNoxTypeForKey<Store,Text>("Id", request.EntityDto));
        if (entity == null)
        {
            return false;
        }
        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}