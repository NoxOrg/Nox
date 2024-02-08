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

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateCommissionCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CommissionKeyDto>;

internal partial class PartialUpdateCommissionCommandHandler : PartialUpdateCommissionCommandHandlerBase
{
	public PartialUpdateCommissionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCommissionCommandHandlerBase : CommandBase<PartialUpdateCommissionCommand, CommissionEntity>, IRequestHandler<PartialUpdateCommissionCommand, CommissionKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCommissionCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CommissionKeyDto> Handle(PartialUpdateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CommissionMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<Cryptocash.Domain.Commission>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CommissionKeyDto(entity.Id.Value);
	}
}