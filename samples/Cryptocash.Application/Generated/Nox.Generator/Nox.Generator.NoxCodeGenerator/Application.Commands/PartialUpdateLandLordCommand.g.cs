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
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public partial record PartialUpdateLandLordCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <LandLordKeyDto>;

internal partial class PartialUpdateLandLordCommandHandler : PartialUpdateLandLordCommandHandlerBase
{
	public PartialUpdateLandLordCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateLandLordCommandHandlerBase : CommandBase<PartialUpdateLandLordCommand, LandLordEntity>, IRequestHandler<PartialUpdateLandLordCommand, LandLordKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> EntityFactory { get; }
	
	public PartialUpdateLandLordCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<LandLordEntity, LandLordCreateDto, LandLordUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<LandLordKeyDto> Handle(PartialUpdateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.LandLordMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<LandLord>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("LandLord",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new LandLordKeyDto(entity.Id.Value);
	}
}