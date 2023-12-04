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
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Factories;

internal abstract class TenantFactoryBase : IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.TenantBrand, TenantBrandUpsertDto, TenantBrandUpsertDto> TenantBrandFactory {get;}
    protected IEntityFactory<ClientApi.Domain.TenantContact, TenantContactUpsertDto, TenantContactUpsertDto> TenantContactFactory {get;}

    public TenantFactoryBase(
        IEntityFactory<ClientApi.Domain.TenantBrand, TenantBrandUpsertDto, TenantBrandUpsertDto> tenantbrandfactory,
        IEntityFactory<ClientApi.Domain.TenantContact, TenantContactUpsertDto, TenantContactUpsertDto> tenantcontactfactory,
        IRepository repository
        )
    {
        TenantBrandFactory = tenantbrandfactory;
        TenantContactFactory = tenantcontactfactory;
        _repository = repository;
    }

    public virtual TenantEntity CreateEntity(TenantCreateDto createDto)
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

    public virtual void UpdateEntity(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TenantEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.Tenant ToEntity(TenantCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Tenant();
        entity.Name = ClientApi.Domain.TenantMetadata.CreateName(createDto.Name);
		entity.EnsureId();
        createDto.TenantBrands.ForEach(dto => entity.CreateRefToTenantBrands(TenantBrandFactory.CreateEntity(dto)));
        if (createDto.TenantContact is not null)
        {
            entity.CreateRefToTenantContact(TenantContactFactory.CreateEntity(createDto.TenantContact));
        }
        return entity;
    }

    private void UpdateEntityInternal(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.TenantMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
		entity.EnsureId();
	    UpdateOwnedEntities(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TenantEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.TenantMetadata.CreateName(NameUpdateValue);
            }
        }
		entity.EnsureId();
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private void UpdateOwnedEntities(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.TenantBrands.Any())
        { 
            _repository.DeleteOwnedRange(entity.TenantBrands);
			entity.DeleteAllRefToTenantBrands();
        }
		else
		{
			var updatedTenantBrands = new List<ClientApi.Domain.TenantBrand>();
			foreach(var ownedUpsertDto in updateDto.TenantBrands)
			{
				if(ownedUpsertDto.Id is null)
					updatedTenantBrands.Add(TenantBrandFactory.CreateEntity(ownedUpsertDto));
				else
				{
					var key = ClientApi.Domain.TenantBrandMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.TenantBrands.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("TenantBrands.Id", key.ToString());
					else
					{
						TenantBrandFactory.UpdateEntity(ownedEntity, ownedUpsertDto, cultureCode);
						updatedTenantBrands.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwnedRange<ClientApi.Domain.TenantBrand>(
                entity.TenantBrands.Where(x => !updatedTenantBrands.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToTenantBrands(updatedTenantBrands);
		}
		if(updateDto.TenantContact is null)
        {
            if(entity.TenantContact is not null) 
                _repository.DeleteOwned(entity.TenantContact);
			entity.DeleteAllRefToTenantContact();
        }
		else
		{
            if(entity.TenantContact is not null)
                TenantContactFactory.UpdateEntity(entity.TenantContact, updateDto.TenantContact, cultureCode);
            else
			    entity.CreateRefToTenantContact(TenantContactFactory.CreateEntity(updateDto.TenantContact));
		}
	}
}

internal partial class TenantFactory : TenantFactoryBase
{
    public TenantFactory
    (
        IEntityFactory<ClientApi.Domain.TenantBrand, TenantBrandUpsertDto, TenantBrandUpsertDto> tenantbrandfactory,
        IEntityFactory<ClientApi.Domain.TenantContact, TenantContactUpsertDto, TenantContactUpsertDto> tenantcontactfactory,
        IRepository repository
    ) : base(tenantbrandfactory,tenantcontactfactory, repository)
    {}
}