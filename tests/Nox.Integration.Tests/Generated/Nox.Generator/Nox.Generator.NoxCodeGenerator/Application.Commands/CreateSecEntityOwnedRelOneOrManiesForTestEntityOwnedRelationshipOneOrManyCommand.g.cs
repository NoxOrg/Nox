﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecEntityOwnedRelOneOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelOneOrMany;

namespace TestWebApp.Application.Commands;
public partial record CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecEntityOwnedRelOneOrManyUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelOneOrManyKeyDto>;

internal partial class CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler : CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyEntity>, IRequestHandler<CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyKeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> _entityFactory;
	
	protected CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<SecEntityOwnedRelOneOrManyKeyDto?> Handle(CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipOneOrMany",  $"{keyId.ToString()}");
		}

		var entity = await _entityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToSecEntityOwnedRelOneOrManies(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new SecEntityOwnedRelOneOrManyKeyDto(entity.Id.Value);
	}
}

public class CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator : AbstractValidator<CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand>
{
    public CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator()
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}