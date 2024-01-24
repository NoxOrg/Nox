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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateThirdTestEntityZeroOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ThirdTestEntityZeroOrManyKeyDto>;

internal partial class PartialUpdateThirdTestEntityZeroOrManyCommandHandler : PartialUpdateThirdTestEntityZeroOrManyCommandHandlerBase
{
	public PartialUpdateThirdTestEntityZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityZeroOrManyEntity, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateThirdTestEntityZeroOrManyCommandHandlerBase : CommandBase<PartialUpdateThirdTestEntityZeroOrManyCommand, ThirdTestEntityZeroOrManyEntity>, IRequestHandler<PartialUpdateThirdTestEntityZeroOrManyCommand, ThirdTestEntityZeroOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<ThirdTestEntityZeroOrManyEntity, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateThirdTestEntityZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityZeroOrManyEntity, ThirdTestEntityZeroOrManyCreateDto, ThirdTestEntityZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityZeroOrManyKeyDto> Handle(PartialUpdateThirdTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.ThirdTestEntityZeroOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<ThirdTestEntityZeroOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new ThirdTestEntityZeroOrManyKeyDto(entity.Id.Value);
	}
}