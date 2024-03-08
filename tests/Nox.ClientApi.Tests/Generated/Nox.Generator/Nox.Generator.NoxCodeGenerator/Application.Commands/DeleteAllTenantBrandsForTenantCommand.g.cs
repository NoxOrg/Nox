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
using TenantEntity = ClientApi.Domain.Tenant;

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

internal partial class DeleteAllTenantBrandsForTenantCommandHandlerBase : CommandBase<DeleteAllTenantBrandsForTenantCommand, TenantEntity>, IRequestHandler <DeleteAllTenantBrandsForTenantCommand, bool>
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
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Tenant, ClientApi.Domain.TenantBrand, ClientApi.Domain.TenantBrandLocalized>(
			keys.ToArray(), 
			p => p.TenantBrands, 
			l => l.LocalizedTenantBrands, 
			cancellationToken);
		
		EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", "parentKeyId");
		
		Repository.DeleteOwned(parentEntity.TenantBrands);
		
		parentEntity.DeleteAllRefToTenantBrands();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, parentEntity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}