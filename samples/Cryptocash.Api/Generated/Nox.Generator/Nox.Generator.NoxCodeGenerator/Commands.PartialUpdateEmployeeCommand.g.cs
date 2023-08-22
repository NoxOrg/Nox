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

public record PartialUpdateEmployeeCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, HashSet<string> DeletedPropertyNames) : IRequest <EmployeeKeyDto?>;

public class PartialUpdateEmployeeCommandHandler: CommandBase, IRequestHandler<PartialUpdateEmployeeCommand, EmployeeKeyDto?>
{
    public CryptocashApiDbContext DbContext { get; }    
    public IEntityMapper<Employee> EntityMapper { get; }

    public PartialUpdateEmployeeCommandHandler(
        CryptocashApiDbContext dbContext,        
        NoxSolution noxSolution,
        IServiceProvider serviceProvider,
        IEntityMapper<Employee> entityMapper): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;        
        EntityMapper = entityMapper;
    }
    
    public async Task<EmployeeKeyDto?> Handle(PartialUpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var keyId = CreateNoxTypeForKey<Employee,DatabaseNumber>("Id", request.keyId);
    
        var entity = await DbContext.Employees.FindAsync(keyId);
        if (entity == null)
        {
            return null;
        }
        EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Employee>(), request.UpdatedProperties, request.DeletedPropertyNames);

        DbContext.Entry(entity).State = EntityState.Modified;
        var result = await DbContext.SaveChangesAsync();
        return new EmployeeKeyDto(entity.Id.Value);
    }
}