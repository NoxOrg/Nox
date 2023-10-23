﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record UpdateThirdTestEntityZeroOrOneCommand(System.String keyId, ThirdTestEntityZeroOrOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<ThirdTestEntityZeroOrOneKeyDto?>;

internal partial class UpdateThirdTestEntityZeroOrOneCommandHandler : UpdateThirdTestEntityZeroOrOneCommandHandlerBase
{
	public UpdateThirdTestEntityZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateThirdTestEntityZeroOrOneCommandHandlerBase : CommandBase<UpdateThirdTestEntityZeroOrOneCommand, ThirdTestEntityZeroOrOneEntity>, IRequestHandler<UpdateThirdTestEntityZeroOrOneCommand, ThirdTestEntityZeroOrOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> _entityFactory;

	public UpdateThirdTestEntityZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityZeroOrOneEntity, ThirdTestEntityZeroOrOneCreateDto, ThirdTestEntityZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityZeroOrOneKeyDto?> Handle(UpdateThirdTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ThirdTestEntityZeroOrOneKeyDto(entity.Id.Value);
	}
}