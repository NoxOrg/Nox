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

namespace Cryptocash.Application;

public class CustomerPaymentDetailsMapper: EntityMapperBase<CustomerPaymentDetails>
{
    public  CustomerPaymentDetailsMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CustomerPaymentDetails entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"PaymentAccountName",dto.PaymentAccountName);
        if(noxTypeValue != null)
        {        
            entity.PaymentAccountName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"PaymentAccountNumber",dto.PaymentAccountNumber);
        if(noxTypeValue != null)
        {        
            entity.PaymentAccountNumber = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"PaymentAccountSortCode",dto.PaymentAccountSortCode);
        if(noxTypeValue != null)
        {        
            entity.PaymentAccountSortCode = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CustomerPaymentDetails entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("PaymentAccountName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"PaymentAccountName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerPaymentDetails", "PaymentAccountName");
                }
                else
                {
                    entity.PaymentAccountName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PaymentAccountNumber", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"PaymentAccountNumber",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerPaymentDetails", "PaymentAccountNumber");
                }
                else
                {
                    entity.PaymentAccountNumber = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PaymentAccountSortCode", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"PaymentAccountSortCode",value);
                if(noxTypeValue == null)
                {
                    entity.PaymentAccountSortCode = null;
                }
                else
                {
                    entity.PaymentAccountSortCode = noxTypeValue;
                }
            }
        }
    }
}