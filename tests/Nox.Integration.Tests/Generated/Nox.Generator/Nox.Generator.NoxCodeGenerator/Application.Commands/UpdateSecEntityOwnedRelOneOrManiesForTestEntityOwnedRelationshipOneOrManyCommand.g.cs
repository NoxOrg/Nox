﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecEntityOwnedRelOneOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelOneOrMany;
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecEntityOwnedRelOneOrManyUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelOneOrManyKeyDto>;

internal partial class UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler : UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyEntity>, IRequestHandler <UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyKeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> _entityFactory;

	protected UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecEntityOwnedRelOneOrManyKeyDto> Handle(UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await _dbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipOneOrMany",  $"{keyId.ToString()}");
		}
		await _dbContext.Entry(parentEntity).Collection(p => p.SecEntityOwnedRelOneOrManies).LoadAsync(cancellationToken);
		
		SecEntityOwnedRelOneOrManyEntity? entity;
		if(request.EntityDto.Id is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity);
		}
		else
		{
			var ownedId = TestWebApp.Domain.SecEntityOwnedRelOneOrManyMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.String>());
			entity = parentEntity.SecEntityOwnedRelOneOrManies.SingleOrDefault(x => x.Id == ownedId);
			if (entity is null)
				entity = await CreateEntityAsync(request.EntityDto, parentEntity);
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;


		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return new SecEntityOwnedRelOneOrManyKeyDto(entity.Id.Value);
	}
	
	private async Task<SecEntityOwnedRelOneOrManyEntity> CreateEntityAsync(SecEntityOwnedRelOneOrManyUpsertDto upsertDto, TestEntityOwnedRelationshipOneOrManyEntity parent)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto);
		parent.CreateRefToSecEntityOwnedRelOneOrManies(entity);
		return entity;
	}
}

public class UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator : AbstractValidator<UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand>
{
    public UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator()
    {		
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}