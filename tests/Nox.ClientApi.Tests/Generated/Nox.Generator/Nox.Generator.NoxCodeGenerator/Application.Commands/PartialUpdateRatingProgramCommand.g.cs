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
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateRatingProgramCommand(System.Guid keyStoreId, System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <RatingProgramKeyDto>;

internal partial class PartialUpdateRatingProgramCommandHandler : PartialUpdateRatingProgramCommandHandlerBase
{
	public PartialUpdateRatingProgramCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateRatingProgramCommandHandlerBase : CommandBase<PartialUpdateRatingProgramCommand, RatingProgramEntity>, IRequestHandler<PartialUpdateRatingProgramCommand, RatingProgramKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> EntityFactory { get; }
	
	public PartialUpdateRatingProgramCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<RatingProgramKeyDto> Handle(PartialUpdateRatingProgramCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyStoreId = Dto.RatingProgramMetadata.CreateStoreId(request.keyStoreId);
		var keyId = Dto.RatingProgramMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<RatingProgram>(keyStoreId, keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("RatingProgram",  $"{keyStoreId.ToString()}, {keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new RatingProgramKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}