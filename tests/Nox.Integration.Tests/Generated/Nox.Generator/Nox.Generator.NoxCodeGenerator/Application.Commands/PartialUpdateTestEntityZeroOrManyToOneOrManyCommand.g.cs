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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityZeroOrManyToOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityZeroOrManyToOneOrManyKeyDto>;

internal partial class PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandler : PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityZeroOrManyToOneOrManyCommand, TestEntityZeroOrManyToOneOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityZeroOrManyToOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToOneOrManyKeyDto> Handle(PartialUpdateTestEntityZeroOrManyToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityZeroOrManyToOneOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityZeroOrManyToOneOrManyKeyDto(entity.Id.Value);
	}
}