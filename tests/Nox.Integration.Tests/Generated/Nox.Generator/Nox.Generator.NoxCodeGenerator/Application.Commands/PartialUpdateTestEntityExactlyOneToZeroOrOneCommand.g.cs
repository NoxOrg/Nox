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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityExactlyOneToZeroOrOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityExactlyOneToZeroOrOneKeyDto>;

internal partial class PartialUpdateTestEntityExactlyOneToZeroOrOneCommandHandler : PartialUpdateTestEntityExactlyOneToZeroOrOneCommandHandlerBase
{
	public PartialUpdateTestEntityExactlyOneToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityExactlyOneToZeroOrOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler<PartialUpdateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrOneKeyDto> Handle(PartialUpdateTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityExactlyOneToZeroOrOneKeyDto(entity.Id.Value);
	}
}