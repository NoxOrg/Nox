﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;

public partial record DeleteAllTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllTenantBrandsForTenantCommandHandler : DeleteAllTenantBrandsForTenantCommandHandlerBase
{
	public DeleteAllTenantBrandsForTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllTenantBrandsForTenantCommandHandlerBase : CommandCollectionBase<DeleteAllTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <DeleteAllTenantBrandsForTenantCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllTenantBrandsForTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));
		
		
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Tenant>(keys.ToArray(), p => p.TenantBrands, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", "parentKeyId");
		
		if(parentEntity.TenantBrands is not null)
		{
			Repository.DeleteOwned(parentEntity.TenantBrands!);
			await OnCompletedAsync(request, parentEntity.TenantBrands!);
		}
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}