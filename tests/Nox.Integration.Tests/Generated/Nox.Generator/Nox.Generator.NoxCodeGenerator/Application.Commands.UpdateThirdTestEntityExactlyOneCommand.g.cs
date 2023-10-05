﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public record UpdateThirdTestEntityExactlyOneCommand(System.String keyId, ThirdTestEntityExactlyOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<ThirdTestEntityExactlyOneKeyDto?>;

internal partial class UpdateThirdTestEntityExactlyOneCommandHandler : UpdateThirdTestEntityExactlyOneCommandHandlerBase
{
	public UpdateThirdTestEntityExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateThirdTestEntityExactlyOneCommandHandlerBase : CommandBase<UpdateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneEntity>, IRequestHandler<UpdateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> _entityFactory;

	public UpdateThirdTestEntityExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityExactlyOneKeyDto?> Handle(UpdateThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ThirdTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}