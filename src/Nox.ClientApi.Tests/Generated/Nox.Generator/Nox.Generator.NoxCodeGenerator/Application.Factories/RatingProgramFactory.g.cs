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
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Factories;

internal abstract class RatingProgramFactoryBase : IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public RatingProgramFactoryBase()
    {
    }

    public virtual RatingProgramEntity CreateEntity(RatingProgramCreateDto createDto)
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

    public virtual void UpdateEntity(RatingProgramEntity entity, RatingProgramUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(RatingProgramEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.RatingProgram ToEntity(RatingProgramCreateDto createDto)
    {
        var entity = new ClientApi.Domain.RatingProgram();
        entity.StoreId = RatingProgramMetadata.CreateStoreId(createDto.StoreId);
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name =ClientApi.Domain.RatingProgramMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        return entity;
    }

    private void UpdateEntityInternal(RatingProgramEntity entity, RatingProgramUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(updateDto.Name is null)
        {
             entity.Name = null;
        }
        else
        {
            entity.Name = ClientApi.Domain.RatingProgramMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(RatingProgramEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null) { entity.Name = null; }
            else
            {
                entity.Name = ClientApi.Domain.RatingProgramMetadata.CreateName(NameUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class RatingProgramFactory : RatingProgramFactoryBase
{
}