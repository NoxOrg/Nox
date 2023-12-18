// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateThirdTestEntityOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ThirdTestEntityOneOrManyKeyDto>;

internal partial class PartialUpdateThirdTestEntityOneOrManyCommandHandler : PartialUpdateThirdTestEntityOneOrManyCommandHandlerBase
{
	public PartialUpdateThirdTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateThirdTestEntityOneOrManyCommandHandlerBase : CommandBase<PartialUpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyEntity>, IRequestHandler<PartialUpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateThirdTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityOneOrManyKeyDto> Handle(PartialUpdateThirdTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  $"{keyId.ToString()}");
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ThirdTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}