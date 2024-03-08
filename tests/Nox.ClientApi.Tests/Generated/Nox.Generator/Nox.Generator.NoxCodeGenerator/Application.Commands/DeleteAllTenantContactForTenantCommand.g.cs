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

internal partial class DeleteAllTenantContactForTenantCommandHandlerBase : CommandBase<DeleteAllTenantContactForTenantCommand, TenantEntity>, IRequestHandler <DeleteAllTenantContactForTenantCommand, bool>
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
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Tenant, ClientApi.Domain.TenantContact, ClientApi.Domain.TenantContactLocalized>(
			keys.ToArray(), 
			p => p.TenantContact, 
		l => l.LocalizedTenantContacts, 
		cancellationToken);
		
		EntityNotFoundException.ThrowIfNull(parentEntity, "Tenant", "parentKeyId");
		
		if(parentEntity.TenantContact is not null)
		{
			Repository.DeleteOwned(parentEntity.TenantContact!);
		}
		
		parentEntity.DeleteAllRefToTenantContact();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, parentEntity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}