// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using CryptocashApi.Application.Dto;
using CryptocashApi.Domain;


namespace CryptocashApi.Application;

public class EmployeeMapper: EntityMapperBase<Employee>
{
    public  EmployeeMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Employee entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FirstName",dto.FirstName);
        if(noxTypeValue != null)
        {        
            entity.FirstName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"LastName",dto.LastName);
        if(noxTypeValue != null)
        {        
            entity.LastName = noxTypeValue;
        }

        // TODO map Email Email remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"Address",dto.Address);
        if(noxTypeValue != null)
        {        
            entity.Address = noxTypeValue;
        }

        // TODO map FirstWorkingDay Date remaining types and remove if else

        // TODO map LastWorkingDay Date remaining types and remove if else
    }
}