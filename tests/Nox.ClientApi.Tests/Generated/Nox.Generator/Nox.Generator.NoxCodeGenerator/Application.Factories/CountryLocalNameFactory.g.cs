
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
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Factories;

internal partial class CountryLocalNameFactory : CountryLocalNameFactoryBase
{
    public CountryLocalNameFactory
    (
        IRepository repository,
        IEntityLocalizedFactory<CountryLocalNameLocalized, CountryLocalNameEntity, CountryLocalNameUpsertDto> countryLocalNameLocalizedFactory,
        NoxSolution noxSolution
    ) : base(repository, countryLocalNameLocalizedFactory, noxSolution)
    {}
}

internal abstract class CountryLocalNameFactoryBase : IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto>
{
    private readonly Nox.Types.CultureCode _defaultCultureCode;
    protected readonly IEntityLocalizedFactory<CountryLocalNameLocalized, CountryLocalNameEntity, CountryLocalNameUpsertDto> CountryLocalNameLocalizedFactory;
    private readonly IRepository _repository;

    public CountryLocalNameFactoryBase(
        IRepository repository,
        IEntityLocalizedFactory<CountryLocalNameLocalized, CountryLocalNameEntity, CountryLocalNameUpsertDto> countryLocalNameLocalizedFactory,
        NoxSolution noxSolution
        )
    {
        _repository = repository;
        CountryLocalNameLocalizedFactory = countryLocalNameLocalizedFactory;
        _defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);
    }

    public virtual async Task<CountryLocalNameEntity> CreateEntityAsync(CountryLocalNameUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            CountryLocalNameLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryLocalNameEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CountryLocalNameEntity entity, CountryLocalNameUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await CountryLocalNameLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryLocalNameEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await CountryLocalNameLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryLocalNameEntity));
        }   
    }

    private async Task<ClientApi.Domain.CountryLocalName> ToEntityAsync(CountryLocalNameUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.CountryLocalName();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.CountryLocalNameMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("NativeName", () => entity.SetIfNotNull(createDto.NativeName, (entity) => entity.NativeName = 
            Dto.CountryLocalNameMetadata.CreateNativeName(createDto.NativeName.NonNullValue<System.String>())));
        exceptionCollector.Collect("Description", () => entity.SetIfNotNull(createDto.Description, (entity) => entity.Description = 
            Dto.CountryLocalNameMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryLocalNameEntity entity, CountryLocalNameUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.CountryLocalNameMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(updateDto.NativeName is null)
        {
             entity.NativeName = null;
        }
        else
        {
            exceptionCollector.Collect("NativeName",() =>entity.NativeName = Dto.CountryLocalNameMetadata.CreateNativeName(updateDto.NativeName.ToValueFromNonNull<System.String>()));
        }
        if(IsDefaultCultureCode(cultureCode)) if(updateDto.Description is null)
        {
             entity.Description = null;
        }
        else
        {
            exceptionCollector.Collect("Description",() =>entity.Description = Dto.CountryLocalNameMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>()));
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
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.CountryLocalNameMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("NativeName", out var NativeNameUpdateValue))
        {
            if (NativeNameUpdateValue == null) { entity.NativeName = null; }
            else
            {
                exceptionCollector.Collect("NativeName",() =>entity.NativeName = Dto.CountryLocalNameMetadata.CreateNativeName(NativeNameUpdateValue));
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            if (DescriptionUpdateValue == null) { entity.Description = null; }
            else
            {
                exceptionCollector.Collect("Description",() =>entity.Description = Dto.CountryLocalNameMetadata.CreateDescription(DescriptionUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
    private bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}