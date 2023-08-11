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

public record UpdateCountryCommand(System.String keyId, CountryUpdateDto EntityDto) : IRequest<bool>;

public class UpdateCountryCommandHandler: CommandBase, IRequestHandler<UpdateCountryCommand, bool>
{
    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<Country> EntityMapper { get; }

    public  UpdateCountryCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<Country> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Country,Text>("Id", request.keyId);
    
        var entity = await DbContext.Countries.FindAsync(keyId);
        if (entity == null)
        {
            return false;
        }
        EntityMapper.MapToEntity(entity, GetEntityDefinition<Country>(), request.EntityDto);
        // Todo map dto
        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();             
        return result > 0;        
    }
}