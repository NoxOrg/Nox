
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
    ) : base()
    {}
}

internal abstract class CountryLocalNameFactoryBase : IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto>
{

    public CountryLocalNameFactoryBase(
        )
    {
    }

    public virtual async Task<CountryLocalNameEntity> CreateEntityAsync(CountryLocalNameUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(CountryLocalNameEntity entity, CountryLocalNameUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
=======
>>>>>>> Merge conflicts have been resolved
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
<<<<<<< main
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
=======
>>>>>>> Merge conflicts have been resolved
    }

    private async Task<ClientApi.Domain.CountryLocalName> ToEntityAsync(CountryLocalNameUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.CountryLocalName();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.CountryLocalNameMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("NativeName", () => entity.SetIfNotNull(createDto.NativeName, (entity) => entity.NativeName = 
            ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(createDto.NativeName.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryLocalNameEntity entity, CountryLocalNameUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(updateDto.NativeName is null)
        {
             entity.NativeName = null;
        }
        else
        {
            exceptionCollector.Collect("NativeName",() =>entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(updateDto.NativeName.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("NativeName", out var NativeNameUpdateValue))
        {
            if (NativeNameUpdateValue == null) { entity.NativeName = null; }
            else
            {
                exceptionCollector.Collect("NativeName",() =>entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(NativeNameUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}