﻿// Generated

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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityZeroOrOneToExactlyOneCommand(System.String keyId, TestEntityZeroOrOneToExactlyOneUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityZeroOrOneToExactlyOneKeyDto?>;

internal partial class UpdateTestEntityZeroOrOneToExactlyOneCommandHandler : UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase
{
	public UpdateTestEntityZeroOrOneToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneEntity>, IRequestHandler<UpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToExactlyOneKeyDto?> Handle(UpdateTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.TestEntityExactlyOneToZeroOrOneId is not null)
		{
			var testEntityExactlyOneToZeroOrOneKey = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityExactlyOneToZeroOrOneId.NonNullValue<System.String>());
			var testEntityExactlyOneToZeroOrOneEntity = await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(testEntityExactlyOneToZeroOrOneKey);
						
			if(testEntityExactlyOneToZeroOrOneEntity is not null)
				entity.CreateRefToTestEntityExactlyOneToZeroOrOne(testEntityExactlyOneToZeroOrOneEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrOne", request.EntityDto.TestEntityExactlyOneToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToTestEntityExactlyOneToZeroOrOne();
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

		return new TestEntityZeroOrOneToExactlyOneKeyDto(entity.Id.Value);
	}
}