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
public record CreateCustomerCommand(CustomerCreateDto EntityDto) : IRequest<CustomerKeyDto>;

public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand, CustomerKeyDto>
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
    
    public async Task<CustomerKeyDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.Customers.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return new CustomerKeyDto(entityToCreate.Id.Value);
}
}