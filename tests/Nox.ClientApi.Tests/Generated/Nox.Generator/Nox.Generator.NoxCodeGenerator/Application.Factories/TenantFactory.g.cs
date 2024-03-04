
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
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Factories;

internal partial class TenantFactory : TenantFactoryBase
{
    public TenantFactory
    (
        IRepository repository,
        IEntityFactory<ClientApi.Domain.TenantBrand, TenantBrandUpsertDto, TenantBrandUpsertDto> tenantbrandfactory,
        IEntityFactory<ClientApi.Domain.TenantContact, TenantContactUpsertDto, TenantContactUpsertDto> tenantcontactfactory
    ) : base(repository, tenantbrandfactory, tenantcontactfactory)
    {}
}

internal abstract class TenantFactoryBase : IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.TenantBrand, TenantBrandUpsertDto, TenantBrandUpsertDto> TenantBrandFactory {get;}
    protected IEntityFactory<ClientApi.Domain.TenantContact, TenantContactUpsertDto, TenantContactUpsertDto> TenantContactFactory {get;}

    public TenantFactoryBase(
        IRepository repository,
        IEntityFactory<ClientApi.Domain.TenantBrand, TenantBrandUpsertDto, TenantBrandUpsertDto> tenantbrandfactory,
        IEntityFactory<ClientApi.Domain.TenantContact, TenantContactUpsertDto, TenantContactUpsertDto> tenantcontactfactory
        )
    {
        _repository = repository;
        TenantBrandFactory = tenantbrandfactory;
        TenantContactFactory = tenantcontactfactory;
    }

    public virtual async Task<TenantEntity> CreateEntityAsync(TenantCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TenantEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantEntity));
        }   
    }

    private async Task<ClientApi.Domain.Tenant> ToEntityAsync(TenantCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Tenant();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.TenantMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Status", () => entity.SetIfNotNull(createDto.Status, (entity) => entity.Status = 
            Dto.TenantMetadata.CreateStatus(createDto.Status.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
		entity.EnsureId();
        //createDto.TenantBrands?.ForEach(async dto =>
        //{
        //    var tenantBrand = await TenantBrandFactory.CreateEntityAsync(dto, cultureCode);
        //    entity.CreateRefToTenantBrands(tenantBrand);
        //});
        if(createDto.TenantBrands is not null)
        {
            foreach (var dto in createDto.TenantBrands)
            {
                var tenantBrand = TenantBrandFactory.CreateEntityAsync(dto, cultureCode).Result;
                entity.CreateRefToTenantBrands(tenantBrand);
            }
        }
        if (createDto.TenantContact is not null)
        {
            var tenantContact = await TenantContactFactory.CreateEntityAsync(createDto.TenantContact, cultureCode);
            entity.CreateRefToTenantContact(tenantContact);
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.TenantMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(updateDto.Status is null)
        {
             entity.Status = null;
        }
        else
        {
            exceptionCollector.Collect("Status",() =>entity.Status = Dto.TenantMetadata.CreateStatus(updateDto.Status.ToValueFromNonNull<System.Int32>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
		entity.EnsureId();
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(TenantEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.TenantMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Status", out var StatusUpdateValue))
        {
            if (StatusUpdateValue == null) { entity.Status = null; }
            else
            {
                exceptionCollector.Collect("Status",() =>entity.Status = Dto.TenantMetadata.CreateStatus(StatusUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
		entity.EnsureId();
    }

	private async Task UpdateOwnedEntitiesAsync(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		await UpdateTenantBrandsAsync(entity, updateDto, cultureCode);
		await UpdateTenantContactAsync(entity, updateDto, cultureCode);
	}

    private async Task UpdateTenantBrandsAsync(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(updateDto.TenantBrands is null)
            return;

        if(!updateDto.TenantBrands.Any())
        { 
            _repository.DeleteOwned(entity.TenantBrands);
			entity.DeleteAllRefToTenantBrands();
        }
		else
		{
			var updatedTenantBrands = new List<ClientApi.Domain.TenantBrand>();
			foreach(var ownedUpsertDto in updateDto.TenantBrands)
			{
				if(ownedUpsertDto.Id is null)
                {
                    var ownedEntity = await TenantBrandFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedTenantBrands.Add(ownedEntity);
                }
				else
				{
					var key = Dto.TenantBrandMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.TenantBrands.Find(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("TenantBrands.Id", key.ToString());
					else
					{
						await TenantBrandFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedTenantBrands.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<ClientApi.Domain.TenantBrand>(
                entity.TenantBrands.Where(x => !updatedTenantBrands.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToTenantBrands(updatedTenantBrands);
		}
	}

    private async Task UpdateTenantContactAsync(TenantEntity entity, TenantUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(updateDto.TenantContact is null)
        {
            if(entity.TenantContact is not null) 
                _repository.DeleteOwned(entity.TenantContact);
            entity.DeleteAllRefToTenantContact();
        }
		else
		{
            if(entity.TenantContact is not null)
                await TenantContactFactory.UpdateEntityAsync(entity.TenantContact, updateDto.TenantContact, cultureCode);
            else
			    entity.CreateRefToTenantContact(await TenantContactFactory.CreateEntityAsync(updateDto.TenantContact, cultureCode));
        }
	}
}