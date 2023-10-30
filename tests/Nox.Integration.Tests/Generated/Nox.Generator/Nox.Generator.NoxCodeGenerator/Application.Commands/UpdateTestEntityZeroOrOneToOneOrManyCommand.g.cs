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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public record UpdateTestEntityZeroOrOneToOneOrManyCommand(System.String keyId, TestEntityZeroOrOneToOneOrManyUpdateDto EntityDto, System.Guid? Etag) : IRequest<TestEntityZeroOrOneToOneOrManyKeyDto?>;

internal partial class UpdateTestEntityZeroOrOneToOneOrManyCommandHandler : UpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase
{
	public UpdateTestEntityZeroOrOneToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler<UpdateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> _entityFactory;

	public UpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToOneOrManyKeyDto?> Handle(UpdateTestEntityZeroOrOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.TestEntityOneOrManyToZeroOrOneId is not null)
		{
			var testEntityOneOrManyToZeroOrOneKey = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.EntityDto.TestEntityOneOrManyToZeroOrOneId.NonNullValue<System.String>());
			var testEntityOneOrManyToZeroOrOneEntity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(testEntityOneOrManyToZeroOrOneKey);
						
			if(testEntityOneOrManyToZeroOrOneEntity is not null)
				entity.CreateRefToTestEntityOneOrManyToZeroOrOne(testEntityOneOrManyToZeroOrOneEntity);
			else
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrOne", request.EntityDto.TestEntityOneOrManyToZeroOrOneId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToTestEntityOneOrManyToZeroOrOne();
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

		return new TestEntityZeroOrOneToOneOrManyKeyDto(entity.Id.Value);
	}
}