// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateCustomerCommand(System.Int64 key, Dictionary<string, dynamic> UpdatedProperties, List<string> DeletedPropertyNames) : IRequest<bool>;

public class PartialUpdateCustomerCommandHandler: CommandBase, IRequestHandler<PartialUpdateCustomerCommand, bool>
{
    public CryptocashApiDbContext DbContext { get; }    
    public IEntityMapper<Customer> EntityMapper { get; }

    public PartialUpdateCustomerCommandHandler(
        CryptocashApiDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<Customer> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<bool> Handle(PartialUpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await DbContext.Customers.FindAsync(CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.key));
        if (entity == null)
        {
            return false;
        }
        //EntityMapper.MapToEntity(entity, GetEntityDefinition<Customer>(), request.EntityDto);
        //// Todo map dto
        //DbContext.Entry(entity).State = EntityState.Modified;
        //var result = await DbContext.SaveChangesAsync();             
        //return result > 0;        
        return true;
    }
}