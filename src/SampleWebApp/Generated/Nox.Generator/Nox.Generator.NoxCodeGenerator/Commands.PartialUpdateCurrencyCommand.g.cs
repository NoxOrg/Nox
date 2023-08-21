// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;

public record PartialUpdateCurrencyCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateCurrencyCommandHandler: CommandBase, IRequestHandler<PartialUpdateCurrencyCommand, bool>
{
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public SampleWebAppDbContext DbContext { get; }    
    public IEntityMapper<Currency> EntityMapper { get; }

    public PartialUpdateCurrencyCommandHandler(
        SampleWebAppDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<Currency> entityMapper,
        IUserProvider userProvider,
        ISystemProvider systemProvider) : base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
        _userProvider = userProvider;
        _systemProvider = systemProvider;
    }
    
    public async Task<bool> Handle(PartialUpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Currency,Nuid>("Id", request.keyId);
    
        var entity = await DbContext.Currencies.FindAsync(keyId);
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<Currency>(), request.EntityDto);
        
        var updatedBy = _userProvider.GetUser();
        var updatedVia = _systemProvider.GetSystem();
        entity.Updated(updatedBy, updatedVia);

        //// Todo map dto
        //DbContext.Entry(entity).State = EntityState.Modified;
        //var result = await DbContext.SaveChangesAsync();             
        //return result > 0;        
        return true;
    }
}