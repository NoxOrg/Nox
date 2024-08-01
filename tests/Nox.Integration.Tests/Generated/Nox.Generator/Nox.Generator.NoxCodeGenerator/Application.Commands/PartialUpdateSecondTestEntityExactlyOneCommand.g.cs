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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateSecondTestEntityExactlyOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityExactlyOneKeyDto>;

internal partial class PartialUpdateSecondTestEntityExactlyOneCommandHandler : PartialUpdateSecondTestEntityExactlyOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityExactlyOneCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneEntity>, IRequestHandler<PartialUpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateSecondTestEntityExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto> Handle(PartialUpdateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.SecondTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityExactlyOne>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new SecondTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}