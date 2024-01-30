// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
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

public partial record PartialUpdateTenantCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TenantKeyDto>;

internal partial class PartialUpdateTenantCommandHandler : PartialUpdateTenantCommandHandlerBase
{
	public PartialUpdateTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTenantCommandHandlerBase : CommandBase<PartialUpdateTenantCommand, TenantEntity>, IRequestHandler<PartialUpdateTenantCommand, TenantKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TenantKeyDto> Handle(PartialUpdateTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TenantMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Tenant>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TenantKeyDto(entity.Id.Value);
	}
}