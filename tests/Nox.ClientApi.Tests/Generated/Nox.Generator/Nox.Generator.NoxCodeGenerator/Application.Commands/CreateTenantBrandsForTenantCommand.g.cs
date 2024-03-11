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

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record CreateTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantBrandKeyDto>;

internal partial class CreateTenantBrandsForTenantCommandHandler : CreateTenantBrandsForTenantCommandHandlerBase
{
	public CreateTenantBrandsForTenantCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateTenantBrandsForTenantCommandHandlerBase : CommandBase<CreateTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler<CreateTenantBrandsForTenantCommand, TenantBrandKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> RntityFactory;
	
	protected CreateTenantBrandsForTenantCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<TenantBrandKeyDto?> Handle(CreateTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<ClientApi.Domain.Tenant> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateTenantBrands(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);		
		await Repository.SaveChangesAsync();

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