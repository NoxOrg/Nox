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
public partial record DeleteTenantBrandsForTenantCommand(TenantKeyDto ParentKeyDto, TenantBrandKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteTenantBrandsForTenantCommandHandler : DeleteTenantBrandsForTenantCommandHandlerBase
{
	public DeleteTenantBrandsForTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteTenantBrandsForTenantCommandHandlerBase : CommandBase<DeleteTenantBrandsForTenantCommand, TenantBrandEntity>, IRequestHandler <DeleteTenantBrandsForTenantCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTenantBrandsForTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTenantBrandsForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<Tenant>(keys.ToArray(), p => p.TenantBrands, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  "keyId");
		}
		var ownedId = Dto.TenantBrandMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.TenantBrands.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TenantBrand.TenantBrands",  $"ownedId");
		}
		parentEntity.TenantBrands.Remove(entity);
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}