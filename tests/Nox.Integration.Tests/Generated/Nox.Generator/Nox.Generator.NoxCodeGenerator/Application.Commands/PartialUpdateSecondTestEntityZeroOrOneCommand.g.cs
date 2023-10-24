﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record PartialUpdateSecondTestEntityZeroOrOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <SecondTestEntityZeroOrOneKeyDto?>;

internal class PartialUpdateSecondTestEntityZeroOrOneCommandHandler : PartialUpdateSecondTestEntityZeroOrOneCommandHandlerBase
{
	public PartialUpdateSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateSecondTestEntityZeroOrOneCommandHandlerBase : CommandBase<PartialUpdateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneEntity>, IRequestHandler<PartialUpdateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> EntityFactory { get; }

	public PartialUpdateSecondTestEntityZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrOneEntity, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrOneKeyDto?> Handle(PartialUpdateSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new SecondTestEntityZeroOrOneKeyDto(entity.Id.Value);
	}
}