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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityOneOrManyKeyDto>;

internal partial class PartialUpdateTestEntityOneOrManyCommandHandler : PartialUpdateTestEntityOneOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityOneOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityOneOrManyCommand, TestEntityOneOrManyEntity>, IRequestHandler<PartialUpdateTestEntityOneOrManyCommand, TestEntityOneOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyKeyDto> Handle(PartialUpdateTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestEntityOneOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}