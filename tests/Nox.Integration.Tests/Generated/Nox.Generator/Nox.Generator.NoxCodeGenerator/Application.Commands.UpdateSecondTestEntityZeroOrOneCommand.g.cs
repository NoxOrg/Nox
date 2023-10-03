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
using SecondTestEntityZeroOrOne = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public record UpdateSecondTestEntityZeroOrOneCommand(System.String keyId, SecondTestEntityZeroOrOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<SecondTestEntityZeroOrOneKeyDto?>;

internal partial class UpdateSecondTestEntityZeroOrOneCommandHandler: UpdateSecondTestEntityZeroOrOneCommandHandlerBase
{
	public UpdateSecondTestEntityZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityZeroOrOneCommandHandlerBase: CommandBase<UpdateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOne>, IRequestHandler<UpdateSecondTestEntityZeroOrOneCommand, SecondTestEntityZeroOrOneKeyDto?>
{
	public TestWebAppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> _entityFactory;

	public UpdateSecondTestEntityZeroOrOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrOne, SecondTestEntityZeroOrOneCreateDto, SecondTestEntityZeroOrOneUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrOneKeyDto?> Handle(UpdateSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(keyId);
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

		return new SecondTestEntityZeroOrOneKeyDto(entity.Id.Value);
	}
}