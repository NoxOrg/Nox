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

internal partial class RatingProgramFactory : RatingProgramFactoryBase
{
    public RatingProgramFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class RatingProgramFactoryBase : IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public RatingProgramFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<RatingProgramEntity> CreateEntityAsync(RatingProgramCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(RatingProgramEntity entity, RatingProgramUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(RatingProgramEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.RatingProgram> ToEntityAsync(RatingProgramCreateDto createDto)
    {
        var entity = new ClientApi.Domain.RatingProgram();
        entity.StoreId = RatingProgramMetadata.CreateStoreId(createDto.StoreId.NonNullValue<System.Guid>());
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.RatingProgramMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(RatingProgramEntity entity, RatingProgramUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(updateDto.Name is null)
        {
             entity.Name = null;
        }
        else
        {
            entity.Name = ClientApi.Domain.RatingProgramMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>());
        }
        await Task.CompletedTask;
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