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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityOneOrManyToZeroOrOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityOneOrManyToZeroOrOneKeyDto>;

internal partial class PartialUpdateTestEntityOneOrManyToZeroOrOneCommandHandler : PartialUpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase
{
	public PartialUpdateTestEntityOneOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler<PartialUpdateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrOneKeyDto> Handle(PartialUpdateTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrOneKeyDto(entity.Id.Value);
	}
}