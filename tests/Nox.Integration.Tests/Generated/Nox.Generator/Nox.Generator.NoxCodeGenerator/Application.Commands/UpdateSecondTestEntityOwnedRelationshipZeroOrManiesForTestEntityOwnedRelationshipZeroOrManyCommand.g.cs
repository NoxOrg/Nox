﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto EntityDto, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>;

internal partial class UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler : UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler <UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> _entityFactory;

	public UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrManyEntity, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto, SecondTestEntityOwnedRelationshipZeroOrManyUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipZeroOrManyKeyDto?> Handle(UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipZeroOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.SecondTestEntityOwnedRelationshipZeroOrManies).LoadAsync(cancellationToken);
		var ownedId = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.String>());
		var entity = parentEntity.SecondTestEntityOwnedRelationshipZeroOrManies.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(entity.Id.Value);
	}
}

public class UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyValidator : AbstractValidator<UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand>
{
    public UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyValidator(ILogger<UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand> logger)
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}