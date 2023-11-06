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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityExactlyOneToZeroOrOneCommand(System.String keyId, TestEntityExactlyOneToZeroOrOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityExactlyOneToZeroOrOneKeyDto?>;

internal partial class UpdateTestEntityExactlyOneToZeroOrOneCommandHandler : UpdateTestEntityExactlyOneToZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityExactlyOneToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityExactlyOneToZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler<UpdateTestEntityExactlyOneToZeroOrOneCommand, TestEntityExactlyOneToZeroOrOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> _entityFactory;

	public UpdateTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrOneKeyDto?> Handle(UpdateTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var testEntityZeroOrOneToExactlyOneKey = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.EntityDto.TestEntityZeroOrOneToExactlyOneId);
		var testEntityZeroOrOneToExactlyOneEntity = await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(testEntityZeroOrOneToExactlyOneKey);
						
		if(testEntityZeroOrOneToExactlyOneEntity is not null)
			entity.CreateRefToTestEntityZeroOrOneToExactlyOne(testEntityZeroOrOneToExactlyOneEntity);
		else
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne", request.EntityDto.TestEntityZeroOrOneToExactlyOneId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new TestEntityExactlyOneToZeroOrOneKeyDto(entity.Id.Value);
	}
}