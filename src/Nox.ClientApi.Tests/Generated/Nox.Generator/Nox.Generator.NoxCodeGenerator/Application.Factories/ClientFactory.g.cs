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
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Factories;

internal abstract class ClientFactoryBase : IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public ClientFactoryBase
    (
        )
    {
    }

    public virtual ClientEntity CreateEntity(ClientCreateDto createDto)
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

    public virtual void UpdateEntity(ClientEntity entity, ClientUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(ClientEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.Client ToEntity(ClientCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Client();
        entity.Name = ClientApi.Domain.ClientMetadata.CreateName(createDto.Name);
        entity.EnsureId(createDto.Id);
        return entity;
    }

    private void UpdateEntityInternal(ClientEntity entity, ClientUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.ClientMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(ClientEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.ClientMetadata.CreateName(NameUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class ClientFactory : ClientFactoryBase
{
}