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

public record UpdateCountryLocalNamesCommand(System.String key, CountryLocalNamesDto EntityDto) : IRequest<bool>;

public class UpdateCountryLocalNamesCommandHandler: CommandBase, IRequestHandler<UpdateCountryLocalNamesCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    

    public  UpdateCountryLocalNamesCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
    }
    
    public async Task<bool> Handle(UpdateCountryLocalNamesCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.CountryLocalNames.FindAsync(CreateNoxTypeForKey<CountryLocalNames,Text>("Id", request.EntityDto));
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