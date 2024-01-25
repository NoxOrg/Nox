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

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityOwnedRelationshipZeroOrOneKeyDto>;

internal partial class PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommandHandler : PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase
{
	public PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler<PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommand, TestEntityOwnedRelationshipZeroOrOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrOneKeyDto> Handle(PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityOwnedRelationshipZeroOrOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityOwnedRelationshipZeroOrOneKeyDto(entity.Id.Value);
	}
}