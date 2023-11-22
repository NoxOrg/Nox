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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Factories;

internal abstract class StoreFactoryBase : IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    protected IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> EmailAddressFactory {get;}

    public StoreFactoryBase
    (
        IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> emailaddressfactory
        )
    {
        EmailAddressFactory = emailaddressfactory;
    }

    public virtual StoreEntity CreateEntity(StoreCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(StoreEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.Store ToEntity(StoreCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Store();
        entity.Name = ClientApi.Domain.StoreMetadata.CreateName(createDto.Name);
        entity.Address = ClientApi.Domain.StoreMetadata.CreateAddress(createDto.Address);
        entity.Location = ClientApi.Domain.StoreMetadata.CreateLocation(createDto.Location);
        entity.SetIfNotNull(createDto.OpeningDay, (entity) => entity.OpeningDay =ClientApi.Domain.StoreMetadata.CreateOpeningDay(createDto.OpeningDay.NonNullValue<System.DateTimeOffset>()));
        entity.SetIfNotNull(createDto.Status, (entity) => entity.Status =ClientApi.Domain.StoreMetadata.CreateStatus(createDto.Status.NonNullValue<System.Int32>()));
        entity.EnsureId(createDto.Id);
        if (createDto.EmailAddress is not null)
        {
            entity.CreateRefToEmailAddress(EmailAddressFactory.CreateEntity(createDto.EmailAddress));
        }
        return entity;
    }

    private void UpdateEntityInternal(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.StoreMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Address = ClientApi.Domain.StoreMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
        entity.Location = ClientApi.Domain.StoreMetadata.CreateLocation(updateDto.Location.NonNullValue<LatLongDto>());
        if(updateDto.OpeningDay is null)
        {
             entity.OpeningDay = null;
        }
        else
        {
            entity.OpeningDay = ClientApi.Domain.StoreMetadata.CreateOpeningDay(updateDto.OpeningDay.ToValueFromNonNull<System.DateTimeOffset>());
        }
        if(updateDto.Status is null)
        {
             entity.Status = null;
        }
        else
        {
            entity.Status = ClientApi.Domain.StoreMetadata.CreateStatus(updateDto.Status.ToValueFromNonNull<System.Int32>());
        }
    }

    private void PartialUpdateEntityInternal(StoreEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.StoreMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            if (AddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Address' can't be null");
            }
            {
                entity.Address = ClientApi.Domain.StoreMetadata.CreateAddress(AddressUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Location", out var LocationUpdateValue))
        {
            if (LocationUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Location' can't be null");
            }
            {
                entity.Location = ClientApi.Domain.StoreMetadata.CreateLocation(LocationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("OpeningDay", out var OpeningDayUpdateValue))
        {
            if (OpeningDayUpdateValue == null) { entity.OpeningDay = null; }
            else
            {
                entity.OpeningDay = ClientApi.Domain.StoreMetadata.CreateOpeningDay(OpeningDayUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Status", out var StatusUpdateValue))
        {
            if (StatusUpdateValue == null) { entity.Status = null; }
            else
            {
                entity.Status = ClientApi.Domain.StoreMetadata.CreateStatus(StatusUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class StoreFactory : StoreFactoryBase
{
    public StoreFactory
    (
        IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> emailaddressfactory
    ) : base(emailaddressfactory)
    {}
}