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
    private readonly IRepository _repository;

    public WorkplaceFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual WorkplaceEntity CreateEntity(WorkplaceCreateDto createDto)
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
        entity.SetIfNotNull(createDto.Ownership, (entity) => entity.Ownership =ClientApi.Domain.WorkplaceMetadata.CreateOwnership(createDto.Ownership.NonNullValue<System.Int32>()));
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
        if(updateDto.Ownership is null)
        {
             entity.Ownership = null;
        }
        else
        {
            entity.Ownership = ClientApi.Domain.WorkplaceMetadata.CreateOwnership(updateDto.Ownership.ToValueFromNonNull<System.Int32>());
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

        if (updatedProperties.TryGetValue("Ownership", out var OwnershipUpdateValue))
        {
            if (OwnershipUpdateValue == null) { entity.Ownership = null; }
            else
            {
                entity.Ownership = ClientApi.Domain.WorkplaceMetadata.CreateOwnership(OwnershipUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class WorkplaceFactory : WorkplaceFactoryBase
{
    public WorkplaceFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}