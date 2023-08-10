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

public record PartialUpdateCountryLocalNamesCommand(System.String key, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateCountryLocalNamesCommandHandler: CommandBase, IRequestHandler<PartialUpdateCountryLocalNamesCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<CountryLocalNames> EntityMapper { get; }

    public PartialUpdateCountryLocalNamesCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<CountryLocalNames> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(PartialUpdateCountryLocalNamesCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.CountryLocalNames.FindAsync(CreateNoxTypeForKey<CountryLocalNames,Text>("Id", request.key));
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryLocalNames>(), request.EntityDto);
        //// Todo map dto
        //DbContext.Entry(entity).State = EntityState.Modified;
        //var result = await DbContext.SaveChangesAsync();             
        //return result > 0;        
        return true;
    }
}