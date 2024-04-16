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
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateStoreLicenseCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <StoreLicenseKeyDto>;

internal partial class PartialUpdateStoreLicenseCommandHandler : PartialUpdateStoreLicenseCommandHandlerBase
{
	public PartialUpdateStoreLicenseCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateStoreLicenseCommandHandlerBase : CommandBase<PartialUpdateStoreLicenseCommand, StoreLicenseEntity>, IRequestHandler<PartialUpdateStoreLicenseCommand, StoreLicenseKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> EntityFactory { get; }
	
	public PartialUpdateStoreLicenseCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreLicenseKeyDto> Handle(PartialUpdateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.StoreLicenseMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<ClientApi.Domain.StoreLicense>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new StoreLicenseKeyDto(entity.Id.Value);
	}
}