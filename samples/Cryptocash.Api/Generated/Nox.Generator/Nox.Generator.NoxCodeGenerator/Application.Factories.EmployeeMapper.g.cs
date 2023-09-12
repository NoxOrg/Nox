// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using Employee = Cryptocash.Domain.Employee;

namespace Cryptocash.Application;

public partial class EmployeeMapper : EntityMapperBase<Employee>
{
    public EmployeeMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Employee entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used

            
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "FirstName", dto.FirstName);
        if (noxTypeValue == null)
        {
            throw new Exception("FirstName is required can not be set to null");
        }     
            entity.FirstName = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "LastName", dto.LastName);
        if (noxTypeValue == null)
        {
            throw new Exception("LastName is required can not be set to null");
        }     
            entity.LastName = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition, "EmailAddress", dto.EmailAddress);
        if (noxTypeValue == null)
        {
            throw new Exception("EmailAddress is required can not be set to null");
        }     
            entity.EmailAddress = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "Address", dto.Address);
        if (noxTypeValue == null)
        {
            throw new Exception("Address is required can not be set to null");
        }     
            entity.Address = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "FirstWorkingDay", dto.FirstWorkingDay);
        if (noxTypeValue == null)
        {
            throw new Exception("FirstWorkingDay is required can not be set to null");
        }     
            entity.FirstWorkingDay = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "LastWorkingDay", dto.LastWorkingDay);     
            entity.LastWorkingDay = noxTypeValue;
    

        /// <summary>
        /// Employee reviewing ExactlyOne CashStockOrders
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.AutoNumber>(entityDefinition, "EmployeeReviewingCashStockOrder", dto.EmployeeReviewingCashStockOrderId);
        if (noxTypeValue != null)
        {        
            entity.EmployeeReviewingCashStockOrderId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Employee entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("FirstName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "FirstName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "FirstName");
                }
                else
                {
                    entity.FirstName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LastName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "LastName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "LastName");
                }
                else
                {
                    entity.LastName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("EmailAddress", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition, "EmailAddress", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "EmailAddress");
                }
                else
                {
                    entity.EmailAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Address", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "Address", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "Address");
                }
                else
                {
                    entity.Address = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FirstWorkingDay", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "FirstWorkingDay", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "FirstWorkingDay");
                }
                else
                {
                    entity.FirstWorkingDay = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LastWorkingDay", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "LastWorkingDay", value);
                if(noxTypeValue == null)
                {
                    entity.LastWorkingDay = null;
                }
                else
                {
                    entity.LastWorkingDay = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Employee reviewing ExactlyOne CashStockOrders
        /// </summary>
        if (updatedProperties.TryGetValue("CashStockOrderId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.AutoNumber>(entityDefinition, "EmployeeReviewingCashStockOrder", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.EmployeeReviewingCashStockOrderId = noxRelationshipTypeValue;
            }
        }
    }
}