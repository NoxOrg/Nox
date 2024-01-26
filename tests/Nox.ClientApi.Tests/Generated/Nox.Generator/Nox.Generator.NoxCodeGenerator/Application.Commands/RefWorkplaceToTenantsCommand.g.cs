// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public abstract record RefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, TenantKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class CreateRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<CreateRefWorkplaceToTenantsCommand>
{
	public CreateRefWorkplaceToTenantsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefWorkplaceToTenantsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetWorkplace(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTenantsInWorkplace(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Tenant",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTenants(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, List<TenantKeyDto> RelatedEntitiesKeysDtos)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class UpdateRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<UpdateRefWorkplaceToTenantsCommand>
{
	public UpdateRefWorkplaceToTenantsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefWorkplaceToTenantsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetWorkplace(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Tenant>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTenantsInWorkplace(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Tenant", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTenants(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto, TenantKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class DeleteRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<DeleteRefWorkplaceToTenantsCommand>
{
	public DeleteRefWorkplaceToTenantsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefWorkplaceToTenantsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetWorkplace(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTenantsInWorkplace(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Tenant", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTenants(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefWorkplaceToTenantsCommand(WorkplaceKeyDto EntityKeyDto)
	: RefWorkplaceToTenantsCommand(EntityKeyDto);

internal partial class DeleteAllRefWorkplaceToTenantsCommandHandler
	: RefWorkplaceToTenantsCommandHandlerBase<DeleteAllRefWorkplaceToTenantsCommand>
{
	public DeleteAllRefWorkplaceToTenantsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefWorkplaceToTenantsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetWorkplace(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTenants();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefWorkplaceToTenantsCommandHandlerBase<TRequest> : CommandBase<TRequest, WorkplaceEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToTenantsCommand
{
	public IRepository Repository { get; }

	public RefWorkplaceToTenantsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<WorkplaceEntity?> GetWorkplace(WorkplaceKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Workplace>(keys.ToArray(), x => x.Tenants, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Tenant?> GetTenantsInWorkplace(TenantKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Tenant>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, WorkplaceEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}