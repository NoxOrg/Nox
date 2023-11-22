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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Factories;

internal abstract class WorkplaceFactoryBase : IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public WorkplaceFactoryBase
    (
        )
    {
    }

    public virtual WorkplaceEntity CreateEntity(WorkplaceCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(WorkplaceEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.Workplace ToEntity(WorkplaceCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Workplace();
        entity.Name = ClientApi.Domain.WorkplaceMetadata.CreateName(createDto.Name);
        entity.SetIfNotNull(createDto.Description, (entity) => entity.Description =ClientApi.Domain.WorkplaceMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>()));
        return entity;
    }

    private void UpdateEntityInternal(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.WorkplaceMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if(IsDefaultCultureCode(cultureCode)) if(updateDto.Description is null)
        {
             entity.Description = null;
        }
        else
        {
            entity.Description = ClientApi.Domain.WorkplaceMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(WorkplaceEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.WorkplaceMetadata.CreateName(NameUpdateValue);
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            if (DescriptionUpdateValue == null) { entity.Description = null; }
            else
            {
                entity.Description = ClientApi.Domain.WorkplaceMetadata.CreateDescription(DescriptionUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class WorkplaceFactory : WorkplaceFactoryBase
{
}