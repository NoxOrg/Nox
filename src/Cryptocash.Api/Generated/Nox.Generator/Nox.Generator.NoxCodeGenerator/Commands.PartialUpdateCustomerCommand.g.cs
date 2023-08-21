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

public record PartialUpdateCustomerCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, HashSet<string> DeletedPropertyNames) : IRequest <CustomerKeyDto?>;

public class PartialUpdateCustomerCommandHandler: CommandBase, IRequestHandler<PartialUpdateCustomerCommand, CustomerKeyDto?>
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
    
    public async Task<CustomerKeyDto?> Handle(PartialUpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Customer,DatabaseNumber>("Id", request.keyId);
    
        var entity = await DbContext.Customers.FindAsync(keyId);
        if (entity == null)
        {
            return null;
        }
        EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Customer>(), request.UpdatedProperties, request.DeletedPropertyNames);

        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();
        return new CustomerKeyDto(entity.Id.Value);
    }
}