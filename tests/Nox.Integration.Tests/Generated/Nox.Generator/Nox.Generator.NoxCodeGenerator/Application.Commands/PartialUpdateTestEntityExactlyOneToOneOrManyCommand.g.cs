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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityExactlyOneToOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityExactlyOneToOneOrManyKeyDto>;

internal partial class PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandler : PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToOneOrManyKeyDto> Handle(PartialUpdateTestEntityExactlyOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityExactlyOneToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityExactlyOneToOneOrManyKeyDto(entity.Id.Value);
	}
}