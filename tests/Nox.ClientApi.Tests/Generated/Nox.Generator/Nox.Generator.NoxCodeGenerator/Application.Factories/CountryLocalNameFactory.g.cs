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
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Factories;

internal partial class CountryLocalNameFactory : CountryLocalNameFactoryBase
{
    public CountryLocalNameFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CountryLocalNameFactoryBase : IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CountryLocalNameFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CountryLocalNameEntity> CreateEntityAsync(CountryLocalNameUpsertDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(CountryLocalNameEntity entity, CountryLocalNameUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.CountryLocalName> ToEntityAsync(CountryLocalNameUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.CountryLocalName();
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.CountryLocalNameMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.NativeName, (entity) => entity.NativeName = 
            ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(createDto.NativeName.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryLocalNameEntity entity, CountryLocalNameUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if(updateDto.NativeName is null)
        {
             entity.NativeName = null;
        }
        else
        {
            entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(updateDto.NativeName.ToValueFromNonNull<System.String>());
        }
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("NativeName", out var NativeNameUpdateValue))
        {
            if (NativeNameUpdateValue == null) { entity.NativeName = null; }
            else
            {
                entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(NativeNameUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}