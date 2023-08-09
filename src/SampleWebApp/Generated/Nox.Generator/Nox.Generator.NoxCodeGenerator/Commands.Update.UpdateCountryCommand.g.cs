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

public record UpdateCountryCommand(System.String key, CountryDto EntityDto) : IRequest<bool>;

public class UpdateCountryCommandHandler: CommandBase, IRequestHandler<UpdateCountryCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    

    public  UpdateCountryCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.Countries.FindAsync(CreateNoxTypeForKey<Country,Text>("Id", request.EntityDto));
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