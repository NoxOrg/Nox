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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityZeroOrOneToZeroOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityZeroOrOneToZeroOrManyKeyDto>;

internal partial class PartialUpdateTestEntityZeroOrOneToZeroOrManyCommandHandler : PartialUpdateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityZeroOrOneToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityZeroOrOneToZeroOrManyCommand, TestEntityZeroOrOneToZeroOrManyEntity>, IRequestHandler<PartialUpdateTestEntityZeroOrOneToZeroOrManyCommand, TestEntityZeroOrOneToZeroOrManyKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityZeroOrOneToZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToZeroOrManyKeyDto> Handle(PartialUpdateTestEntityZeroOrOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityZeroOrOneToZeroOrManyKeyDto(entity.Id.Value);
	}
}