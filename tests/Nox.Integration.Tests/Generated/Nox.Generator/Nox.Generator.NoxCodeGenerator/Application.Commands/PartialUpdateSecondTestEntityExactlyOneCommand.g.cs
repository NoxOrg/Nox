// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateSecondTestEntityExactlyOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecondTestEntityExactlyOneKeyDto>;

internal partial class PartialUpdateSecondTestEntityExactlyOneCommandHandler : PartialUpdateSecondTestEntityExactlyOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateSecondTestEntityExactlyOneCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneEntity>, IRequestHandler<PartialUpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> EntityFactory { get; }
	
	public PartialUpdateSecondTestEntityExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto> Handle(PartialUpdateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new SecondTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}