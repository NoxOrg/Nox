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
        return await ToEntityAsync(createDto);
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}