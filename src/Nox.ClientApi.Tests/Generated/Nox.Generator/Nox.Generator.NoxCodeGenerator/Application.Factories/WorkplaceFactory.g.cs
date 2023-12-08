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

internal partial class WorkplaceFactory : WorkplaceFactoryBase
{
    public WorkplaceFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

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

    public virtual async Task<WorkplaceEntity> CreateEntityAsync(WorkplaceCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(WorkplaceEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.Workplace> ToEntityAsync(WorkplaceCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Workplace();
        entity.Name = ClientApi.Domain.WorkplaceMetadata.CreateName(createDto.Name);
        entity.SetIfNotNull(createDto.Description, (entity) => entity.Description =ClientApi.Domain.WorkplaceMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Ownership, (entity) => entity.Ownership =ClientApi.Domain.WorkplaceMetadata.CreateOwnership(createDto.Ownership.NonNullValue<System.Int32>()));
        entity.SetIfNotNull(createDto.Type, (entity) => entity.Type =ClientApi.Domain.WorkplaceMetadata.CreateType(createDto.Type.NonNullValue<System.Int32>()));
        var nextSequenceReferenceNumber =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("Workplace", "ReferenceNumber"));
        entity.EnsureReferenceNumber(nextSequenceReferenceNumber,ClientApi.Domain.WorkplaceMetadata.ReferenceNumberTypeOptions);
        return entity;
    }

    private async Task UpdateEntityInternalAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
        if(updateDto.Type is null)
        {
             entity.Type = null;
        }
        else
        {
            entity.Type = ClientApi.Domain.WorkplaceMetadata.CreateType(updateDto.Type.ToValueFromNonNull<System.Int32>());
        }
        await Task.CompletedTask;
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

        if (updatedProperties.TryGetValue("Type", out var TypeUpdateValue))
        {
            if (TypeUpdateValue == null) { entity.Type = null; }
            else
            {
                entity.Type = ClientApi.Domain.WorkplaceMetadata.CreateType(TypeUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}