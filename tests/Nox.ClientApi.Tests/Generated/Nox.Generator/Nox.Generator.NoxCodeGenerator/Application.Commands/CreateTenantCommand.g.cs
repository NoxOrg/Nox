﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record CreateTenantCommand(TenantCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TenantKeyDto>;

internal partial class CreateTenantCommandHandler : CreateTenantCommandHandlerBase
{
	public CreateTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, ClientApi.Domain.TenantBrand, TenantBrandUpsertDto> TenantBrandLocalizedFactory,
		IEntityLocalizedFactory<TenantContactLocalized, ClientApi.Domain.TenantContact, TenantContactUpsertDto> TenantContactLocalizedFactory)
		: base(dbContext, noxSolution,WorkplaceFactory, entityFactory, TenantBrandLocalizedFactory, TenantContactLocalizedFactory)
	{
	}
}


internal abstract class CreateTenantCommandHandlerBase : CommandBase<CreateTenantCommand,TenantEntity>, IRequestHandler <CreateTenantCommand, TenantKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> EntityFactory;
	protected readonly IEntityLocalizedFactory<TenantBrandLocalized, ClientApi.Domain.TenantBrand, TenantBrandUpsertDto> TenantBrandLocalizedFactory;
	protected readonly IEntityLocalizedFactory<TenantContactLocalized, ClientApi.Domain.TenantContact, TenantContactUpsertDto> TenantContactLocalizedFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory;

	protected CreateTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, ClientApi.Domain.TenantBrand, TenantBrandUpsertDto> TenantBrandLocalizedFactory,
		IEntityLocalizedFactory<TenantContactLocalized, ClientApi.Domain.TenantContact, TenantContactUpsertDto> TenantContactLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.TenantBrandLocalizedFactory = TenantBrandLocalizedFactory;
		this.TenantContactLocalizedFactory = TenantContactLocalizedFactory;
		this.WorkplaceFactory = WorkplaceFactory;
	}

	public virtual async Task<TenantKeyDto> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.WorkplacesId.Any())
		{
			foreach(var relatedId in request.EntityDto.WorkplacesId)
			{
				var relatedKey = ClientApi.Domain.WorkplaceMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Workplaces.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToWorkplaces(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Workplaces", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Workplaces)
			{
				var relatedEntity = await WorkplaceFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToWorkplaces(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Tenants.Add(entityToCreate);
		await CreateLocalizationsAsync(entityToCreate, request.CultureCode);
		await DbContext.SaveChangesAsync();
		return new TenantKeyDto(entityToCreate.Id.Value);
	}

	private async Task CreateLocalizationsAsync(TenantEntity entity, Nox.Types.CultureCode cultureCode)
	{
        await CreateTenantBrandsLocalizationAsync(entity.TenantBrands, cultureCode);
        await CreateTenantContactLocalizationAsync(entity.TenantContact, cultureCode);
	}
	private async Task CreateTenantBrandsLocalizationAsync(List<ClientApi.Domain.TenantBrand> entities, Nox.Types.CultureCode cultureCode)
	{
		var entitiesLocalized = new List<TenantBrandLocalized>();
		foreach (var entity in entities)
		{
			var entityLocalized = await TenantBrandLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode);
			entitiesLocalized.Add(entityLocalized);
		}
		DbContext.TenantBrandsLocalized.AddRange(entitiesLocalized);
	}
	
	private async Task CreateTenantContactLocalizationAsync(ClientApi.Domain.TenantContact? entity, Nox.Types.CultureCode cultureCode)
	{
<<<<<<< main
		if (entity is null) return;
		var entityLocalized = TenantContactLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
=======
		if(entity is null) return;
		var entityLocalized = await TenantContactLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode);
>>>>>>> Factory classes refactor has been completed (without tests)
		DbContext.TenantContactsLocalized.Add(entityLocalized);
	}	
	
}

public class CreateTenantValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantValidator()
    {
		RuleFor(x => x.EntityDto.TenantBrands)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("TenantBrands.Id must be null as it is auto generated.");
    }
}