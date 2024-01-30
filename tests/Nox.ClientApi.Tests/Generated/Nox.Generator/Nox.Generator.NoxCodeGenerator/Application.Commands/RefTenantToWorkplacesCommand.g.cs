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
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public abstract record RefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class CreateRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<CreateRefTenantToWorkplacesCommand>
{
	public CreateRefTenantToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTenantToWorkplacesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTenant(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTenantWorkplaces(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Workplace",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToWorkplaces(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, List<WorkplaceKeyDto> RelatedEntitiesKeysDtos)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class UpdateRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<UpdateRefTenantToWorkplacesCommand>
{
	public UpdateRefTenantToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTenantToWorkplacesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTenant(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Workplace>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTenantWorkplaces(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Workplace", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToWorkplaces(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class DeleteRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<DeleteRefTenantToWorkplacesCommand>
{
	public DeleteRefTenantToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTenantToWorkplacesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTenant(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTenantWorkplaces(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Workplace", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToWorkplaces(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTenantToWorkplacesCommand(TenantKeyDto EntityKeyDto)
	: RefTenantToWorkplacesCommand(EntityKeyDto);

internal partial class DeleteAllRefTenantToWorkplacesCommandHandler
	: RefTenantToWorkplacesCommandHandlerBase<DeleteAllRefTenantToWorkplacesCommand>
{
	public DeleteAllRefTenantToWorkplacesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTenantToWorkplacesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTenant(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToWorkplaces();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTenantToWorkplacesCommandHandlerBase<TRequest> : CommandBase<TRequest, TenantEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTenantToWorkplacesCommand
{
	public IRepository Repository { get; }

	public RefTenantToWorkplacesCommandHandlerBase(
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

	protected async Task<TenantEntity?> GetTenant(TenantKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TenantMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Tenant>(keys.ToArray(), x => x.Workplaces, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Workplace?> GetTenantWorkplaces(WorkplaceKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Workplace>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TenantEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}