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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateTestEntityOneOrManyToZeroOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityOneOrManyToZeroOrManyKeyDto>;

internal partial class PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandler : PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase
{
	public PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase : CommandBase<PartialUpdateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler<PartialUpdateTestEntityOneOrManyToZeroOrManyCommand, TestEntityOneOrManyToZeroOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateTestEntityOneOrManyToZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrManyKeyDto> Handle(PartialUpdateTestEntityOneOrManyToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new TestEntityOneOrManyToZeroOrManyKeyDto(entity.Id.Value);
	}
}