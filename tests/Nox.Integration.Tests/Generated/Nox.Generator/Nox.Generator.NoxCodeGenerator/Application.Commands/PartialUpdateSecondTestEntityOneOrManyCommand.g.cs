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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateSecondTestEntityOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityOneOrManyKeyDto>;

internal partial class PartialUpdateSecondTestEntityOneOrManyCommandHandler : PartialUpdateSecondTestEntityOneOrManyCommandHandlerBase
{
	public PartialUpdateSecondTestEntityOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityOneOrManyCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyEntity>, IRequestHandler<PartialUpdateSecondTestEntityOneOrManyCommand, SecondTestEntityOneOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateSecondTestEntityOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOneOrManyEntity, SecondTestEntityOneOrManyCreateDto, SecondTestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOneOrManyKeyDto> Handle(PartialUpdateSecondTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.SecondTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<SecondTestEntityOneOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new SecondTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}