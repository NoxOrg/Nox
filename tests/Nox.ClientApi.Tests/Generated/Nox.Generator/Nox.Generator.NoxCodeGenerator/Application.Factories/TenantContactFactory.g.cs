// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Factories;

internal partial class TenantContactFactory : TenantContactFactoryBase
{
    public TenantContactFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TenantContactFactoryBase : IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TenantContactFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TenantContactEntity> CreateEntityAsync(TenantContactUpsertDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TenantContactEntity entity, TenantContactUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.TenantContact> ToEntityAsync(TenantContactUpsertDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.TenantContact();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.TenantContactMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Description", () => entity.SetIfNotNull(createDto.Description, (entity) => entity.Description = 
            ClientApi.Domain.TenantContactMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>())));
        exceptionCollector.Collect("Email", () => entity.SetIfNotNull(createDto.Email, (entity) => entity.Email = 
            ClientApi.Domain.TenantContactMetadata.CreateEmail(createDto.Email.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TenantContactEntity entity, TenantContactUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = ClientApi.Domain.TenantContactMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(IsDefaultCultureCode(cultureCode)) exceptionCollector.Collect("Description",() => entity.Description = ClientApi.Domain.TenantContactMetadata.CreateDescription(updateDto.Description.NonNullValue<System.String>()));
        exceptionCollector.Collect("Email",() => entity.Email = ClientApi.Domain.TenantContactMetadata.CreateEmail(updateDto.Email.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.TenantContactMetadata.CreateName(NameUpdateValue));
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(DescriptionUpdateValue, "Attribute 'Description' can't be null.");
            {
                exceptionCollector.Collect("Description",() =>entity.Description = ClientApi.Domain.TenantContactMetadata.CreateDescription(DescriptionUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Email", out var EmailUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(EmailUpdateValue, "Attribute 'Email' can't be null.");
            {
                exceptionCollector.Collect("Email",() =>entity.Email = ClientApi.Domain.TenantContactMetadata.CreateEmail(EmailUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}