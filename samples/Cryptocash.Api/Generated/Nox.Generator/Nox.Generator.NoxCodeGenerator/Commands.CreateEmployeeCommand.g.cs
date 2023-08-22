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
public record CreateEmployeeCommand(EmployeeCreateDto EntityDto) : IRequest<EmployeeKeyDto>;

public class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, EmployeeKeyDto>
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
    
    public async Task<EmployeeKeyDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {    
        var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
        DbContext.Employees.Add(entityToCreate);
        await DbContext.SaveChangesAsync();
        return new EmployeeKeyDto(entityToCreate.Id.Value);
}
}