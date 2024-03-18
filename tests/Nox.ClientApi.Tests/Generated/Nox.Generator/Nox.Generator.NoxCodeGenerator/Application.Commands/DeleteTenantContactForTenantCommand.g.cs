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
public partial record DeleteTenantContactForTenantCommand(TenantKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteTenantContactForTenantCommandHandler : DeleteTenantContactForTenantCommandHandlerBase
{
	public DeleteTenantContactForTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteTenantContactForTenantCommandHandlerBase : CommandBase<DeleteTenantContactForTenantCommand, TenantContactEntity>, IRequestHandler <DeleteTenantContactForTenantCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTenantContactForTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTenantContactForTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Tenant, ClientApi.Domain.TenantContact, ClientApi.Domain.TenantContactLocalized>(keys.ToArray(), p => p.TenantContact, p => p.LocalizedTenantContacts, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Tenant",  "keyId");
		}				
		var entity = parentEntity.TenantContact;
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant.TenantContact",  String.Empty);
		}

		parentEntity.DeleteTenantContact(entity);
		
		
		
		parentEntity.Etag = request.Etag ?? System.Guid.Empty;
		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}