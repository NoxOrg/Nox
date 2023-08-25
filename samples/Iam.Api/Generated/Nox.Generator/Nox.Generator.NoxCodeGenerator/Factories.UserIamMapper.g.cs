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
using IamApi.Application.Dto;
using IamApi.Domain;

namespace IamApi.Application;

public class UserIamMapper: EntityMapperBase<UserIam>
{
    public  UserIamMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(UserIam entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"UserName",dto.UserName);
        if(noxTypeValue != null)
        {        
            entity.UserName = noxTypeValue;
        }
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
        noxTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition,"TenantId",dto.TenantId);
        if(noxTypeValue != null)
        {        
            entity.TenantId = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition,"TenantBrandId",dto.TenantBrandId);
        if(noxTypeValue != null)
        {        
            entity.TenantBrandId = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"PrimaryEmailAddress",dto.PrimaryEmailAddress);
        if(noxTypeValue != null)
        {        
            entity.PrimaryEmailAddress = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"SecondaryEmailAddress",dto.SecondaryEmailAddress);
        if(noxTypeValue != null)
        {        
            entity.SecondaryEmailAddress = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition,"CountryIsoCode",dto.CountryIsoCode);
        if(noxTypeValue != null)
        {        
            entity.CountryIsoCode = noxTypeValue;
        }

        // TODO map PrefferedLanguage LanguageCode remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"AccepetdTerms",dto.AccepetdTerms);
        if(noxTypeValue != null)
        {        
            entity.AccepetdTerms = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"EnablePasswordLess",dto.EnablePasswordLess);
        if(noxTypeValue != null)
        {        
            entity.EnablePasswordLess = noxTypeValue;
        }

        // TODO map UserStatus Formula remaining types and remove if else
    }

    public override void PartialMapToEntity(UserIam entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("UserName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"UserName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("UserIam", "UserName");
                }
                else
                {
                    entity.UserName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FirstName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FirstName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("UserIam", "FirstName");
                }
                else
                {
                    entity.FirstName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LastName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"LastName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("UserIam", "LastName");
                }
                else
                {
                    entity.LastName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TenantId", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition,"TenantId",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("UserIam", "TenantId");
                }
                else
                {
                    entity.TenantId = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TenantBrandId", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition,"TenantBrandId",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("UserIam", "TenantBrandId");
                }
                else
                {
                    entity.TenantBrandId = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PrimaryEmailAddress", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"PrimaryEmailAddress",value);
                if(noxTypeValue == null)
                {
                    entity.PrimaryEmailAddress = null;
                }
                else
                {
                    entity.PrimaryEmailAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("SecondaryEmailAddress", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"SecondaryEmailAddress",value);
                if(noxTypeValue == null)
                {
                    entity.SecondaryEmailAddress = null;
                }
                else
                {
                    entity.SecondaryEmailAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryIsoCode", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition,"CountryIsoCode",value);
                if(noxTypeValue == null)
                {
                    entity.CountryIsoCode = null;
                }
                else
                {
                    entity.CountryIsoCode = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PrefferedLanguage", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LanguageCode>(entityDefinition,"PrefferedLanguage",value);
                if(noxTypeValue == null)
                {
                    entity.PrefferedLanguage = null;
                }
                else
                {
                    entity.PrefferedLanguage = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("AccepetdTerms", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"AccepetdTerms",value);
                if(noxTypeValue == null)
                {
                    entity.AccepetdTerms = null;
                }
                else
                {
                    entity.AccepetdTerms = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("EnablePasswordLess", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"EnablePasswordLess",value);
                if(noxTypeValue == null)
                {
                    entity.EnablePasswordLess = null;
                }
                else
                {
                    entity.EnablePasswordLess = noxTypeValue;
                }
            }
        }
    }
}