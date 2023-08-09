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

public record UpdateAllNoxTypeCommand(System.UInt64 key, AllNoxTypeDto EntityDto) : IRequest<bool>;

public class UpdateAllNoxTypeCommandHandler: CommandBase, IRequestHandler<UpdateAllNoxTypeCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    

    public  UpdateAllNoxTypeCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task<bool> Handle(UpdateAllNoxTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.AllNoxTypes.FindAsync(CreateNoxTypeForKey<AllNoxType,DatabaseNumber>("Id", request.EntityDto));
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