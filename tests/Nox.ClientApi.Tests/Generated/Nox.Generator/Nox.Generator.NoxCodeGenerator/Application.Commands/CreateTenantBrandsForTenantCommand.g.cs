﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record CreateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantBrandKeyDto>;

internal partial class CreateTenantBrandsForTenantCommandHandler : CreateTenantBrandsForTenantCommandHandlerBase
{
	public CreateTenantBrandsForTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateTenantBrandsForTenantCommandHandlerBase : CommandBase<CreateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler<CreateTenantBrandsForTenantCommand, TenantBrandKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> _entityFactory;
	
	protected CreateTenantBrandsForTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<TenantBrandKeyDto?> Handle(CreateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Tenants.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToTenantBrands(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

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