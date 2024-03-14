﻿﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record UpdateTenantBrandForSingleTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantBrandKeyDto>;

internal partial class UpdateTenantBrandForSingleTenantCommandHandler : UpdateTenantBrandForSingleTenantCommandHandlerBase
{
	public UpdateTenantBrandForSingleTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateTenantBrandForSingleTenantCommandHandlerBase : CommandBase<UpdateTenantBrandForSingleTenantCommand, TenantBrandEntity>, IRequestHandler <UpdateTenantBrandForSingleTenantCommand, TenantBrandKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> _entityFactory;

	protected UpdateTenantBrandForSingleTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TenantBrandKeyDto> Handle(UpdateTenantBrandForSingleTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Tenant>(keys.ToArray(),e => e.TenantBrands, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant",  "keyId");
		var entity = parentEntity.TenantBrands.Find(e => e.Id == Dto.TenantBrandMetadata.CreateId(request.EntityDto.Id!.Value )); 
		EntityNotFoundException.ThrowIfNull(entity, "TenantBrand",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new TenantBrandKeyDto(entity.Id.Value);
	}
}

public class UpdateTenantBrandForSingleTenantCommandValidator : AbstractValidator<UpdateTenantBrandForSingleTenantCommand>
{
    public UpdateTenantBrandForSingleTenantCommandValidator()
    {
    }
}