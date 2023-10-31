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

    public RatingProgramFactoryBase
    (
        )
    {
    }

    public virtual RatingProgramEntity CreateEntity(RatingProgramCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(RatingProgramEntity entity, RatingProgramUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(RatingProgramEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
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
        entity.SetIfNotNull(updateDto.Name, (entity) => entity.Name = ClientApi.Domain.RatingProgramMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>()));
    }

    private void PartialUpdateEntityInternal(RatingProgramEntity entity, Dictionary<string, dynamic> updatedProperties)
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
        => cultureCode == Nox.Types.CultureCode.From("");
}

internal partial class RatingProgramFactory : RatingProgramFactoryBase
{
}