﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record CreateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantBrandKeyDto?>;

internal partial class CreateTenantBrandsForTenantCommandHandler : CreateTenantBrandsForTenantCommandHandlerBase
{
	public CreateTenantBrandsForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}
internal abstract class CreateTenantBrandsForTenantCommandHandlerBase : CommandBase<CreateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler<CreateTenantBrandsForTenantCommand, TenantBrandKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> _entityFactory;
	protected readonly IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> _entityLocalizedFactory;

	protected CreateTenantBrandsForTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory,
		IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory; 
		_entityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual  async Task<TenantBrandKeyDto?> Handle(CreateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.TenantMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CreateRefToTenantBrands(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, request.CultureCode);
		_dbContext.TenantBrandsLocalized.Add(entityLocalized);

		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TenantBrandKeyDto(entity.Id.Value);
	}
}

public class CreateTenantBrandsForTenantValidator : AbstractValidator<CreateTenantBrandsForTenantCommand>
{
    public CreateTenantBrandsForTenantValidator()
    {
		RuleFor(x => x.EntityDto.Id).Null().WithMessage("Id must be null as it is auto generated.");
    }
}