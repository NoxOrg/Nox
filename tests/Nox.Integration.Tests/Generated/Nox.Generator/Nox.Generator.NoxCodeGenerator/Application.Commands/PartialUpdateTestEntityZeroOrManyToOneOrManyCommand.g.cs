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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityZeroOrManyToOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityZeroOrManyToOneOrManyKeyDto>;

internal partial class PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandler : PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToOneOrManyKeyDto> Handle(PartialUpdateTestEntityZeroOrManyToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrManyToOneOrManyKeyDto(entity.Id.Value);
	}
}