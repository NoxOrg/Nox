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

public record UpdateCountryLocalNamesCommand(System.String key, CountryLocalNamesUpdateDto EntityDto) : IRequest<bool>;

public class UpdateCountryLocalNamesCommandHandler: CommandBase, IRequestHandler<UpdateCountryLocalNamesCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<CountryLocalNames> EntityMapper { get; }

    public  UpdateCountryLocalNamesCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<CountryLocalNames> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(UpdateCountryLocalNamesCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.CountryLocalNames.FindAsync(CreateNoxTypeForKey<CountryLocalNames,Text>("Id", request.key));
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryLocalNames>(), request.EntityDto);
        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}