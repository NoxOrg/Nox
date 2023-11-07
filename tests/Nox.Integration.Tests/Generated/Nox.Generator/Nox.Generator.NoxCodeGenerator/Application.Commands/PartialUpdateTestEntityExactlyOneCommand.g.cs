﻿// Generated

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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record PartialUpdateTestEntityExactlyOneCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <TestEntityExactlyOneKeyDto?>;

internal class PartialUpdateTestEntityExactlyOneCommandHandler : PartialUpdateTestEntityExactlyOneCommandHandlerBase
{
	public PartialUpdateTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateTestEntityExactlyOneCommandHandlerBase : CommandBase<PartialUpdateTestEntityExactlyOneCommand, TestEntityExactlyOneEntity>, IRequestHandler<PartialUpdateTestEntityExactlyOneCommand, TestEntityExactlyOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> EntityFactory { get; }

	public PartialUpdateTestEntityExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneKeyDto?> Handle(PartialUpdateTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new TestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}