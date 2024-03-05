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
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;

public partial record DeleteAllTenantContactForTenantCommand(TenantKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllTenantContactForTenantCommandHandler : DeleteAllTenantContactForTenantCommandHandlerBase
{
	public DeleteAllTenantContactForTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllTenantContactForTenantCommandHandlerBase : CommandBase<DeleteAllTenantContactForTenantCommand, TenantContactEntity>, IRequestHandler <DeleteAllTenantContactForTenantCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllTenantContactForTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllTenantContactForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));
		
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Tenant>(keys.ToArray(), p => p.TenantContact, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", "parentKeyId");
					
		var entity = parentEntity.TenantContact;
		EntityNotFoundException.ThrowIfNull(entity, "Tenant.TenantContact",  String.Empty);

		parentEntity.DeleteAllRefToTenantContact();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}