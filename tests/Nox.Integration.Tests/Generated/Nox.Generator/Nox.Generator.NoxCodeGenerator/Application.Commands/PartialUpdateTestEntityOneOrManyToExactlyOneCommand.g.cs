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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityOneOrManyToExactlyOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityOneOrManyToExactlyOneKeyDto>;

internal partial class PartialUpdateTestEntityOneOrManyToExactlyOneCommandHandler : PartialUpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase
{
	public PartialUpdateTestEntityOneOrManyToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneEntity>, IRequestHandler<PartialUpdateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToExactlyOneKeyDto> Handle(PartialUpdateTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityOneOrManyToExactlyOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToExactlyOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityOneOrManyToExactlyOneKeyDto(entity.Id.Value);
	}
}