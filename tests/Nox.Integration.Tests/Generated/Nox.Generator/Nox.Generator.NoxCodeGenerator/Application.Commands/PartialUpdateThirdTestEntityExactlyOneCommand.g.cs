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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateThirdTestEntityExactlyOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ThirdTestEntityExactlyOneKeyDto>;

internal partial class PartialUpdateThirdTestEntityExactlyOneCommandHandler : PartialUpdateThirdTestEntityExactlyOneCommandHandlerBase
{
	public PartialUpdateThirdTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateThirdTestEntityExactlyOneCommandHandlerBase : CommandBase<PartialUpdateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneEntity>, IRequestHandler<PartialUpdateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateThirdTestEntityExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityExactlyOneKeyDto> Handle(PartialUpdateThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.ThirdTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<ThirdTestEntityExactlyOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityExactlyOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new ThirdTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}