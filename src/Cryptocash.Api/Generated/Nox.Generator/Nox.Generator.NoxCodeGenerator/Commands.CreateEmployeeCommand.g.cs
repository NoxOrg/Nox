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
public record CreateEmployeeCommand(EmployeeCreateDto EntityDto) : IRequest<System.Int64>;

public class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, System.Int64>
{
    public CryptocashApiDbContext DbContext { get; }
    public IEntityFactory<EmployeeCreateDto,Employee> EntityFactory { get; }

    public  CreateEmployeeCommandHandler(
        CryptocashApiDbContext dbContext,
        IEntityFactory<EmployeeCreateDto,Employee> entityFactory)
    {
        DbContext = dbContext;
        EntityFactory = entityFactory;
    }
    
    public async Task<System.Int64> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);        
        //TODO for nuid property or key needs to call ensure id        
        DbContext.Employees.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        //return entityToCreate.Id.Value;
        return default(System.Int64)!;
}
}