// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Application;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
//TODO support multiple keys and generated keys like nuid database number
public record CreateCustomerCommand(CustomerCreateDto EntityDto) : IRequest<System.Int64>;

public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, System.Int64>
{
    public CryptocashApiDbContext DbContext { get; }
    public IEntityFactory<CustomerCreateDto,Customer> EntityFactory { get; }

    public  CreateCustomerCommandHandler(
        CryptocashApiDbContext dbContext,
        IEntityFactory<CustomerCreateDto,Customer> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<System.Int64> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO for nuid property or key needs to call ensure id        
        DbContext.Customers.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return default(System.Int64)!;
}
}