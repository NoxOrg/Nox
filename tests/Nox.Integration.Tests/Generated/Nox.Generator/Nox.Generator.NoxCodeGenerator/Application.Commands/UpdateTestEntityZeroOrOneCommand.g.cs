﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityZeroOrOneCommand(System.String keyId, TestEntityZeroOrOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityZeroOrOneKeyDto?>;

internal partial class UpdateTestEntityZeroOrOneCommandHandler : UpdateTestEntityZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrOneCommand, TestEntityZeroOrOneEntity>, IRequestHandler<UpdateTestEntityZeroOrOneCommand, TestEntityZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneKeyDto?> Handle(UpdateTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityZeroOrOneKeyDto(entity.Id.Value);
	}
}