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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Factories;

internal abstract class LandLordFactoryBase : IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public LandLordFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual LandLordEntity CreateEntity(LandLordCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(LandLordEntity entity, LandLordUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(LandLordEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.LandLord ToEntity(LandLordCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.LandLord();
        entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(createDto.Name);
        entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(createDto.Address);
        entity.EnsureId(createDto.Id);
        return entity;
    }

    private void UpdateEntityInternal(LandLordEntity entity, LandLordUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
    }

    private void PartialUpdateEntityInternal(LandLordEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            if (AddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Address' can't be null");
            }
            {
                var entityToUpdate = entity.Address is null ? new StreetAddressDto() : entity.Address.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, AddressUpdateValue);
                entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(entityToUpdate);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class LandLordFactory : LandLordFactoryBase
{
    public LandLordFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}