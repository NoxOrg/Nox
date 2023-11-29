﻿﻿﻿// Generated

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
using SecondTestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto EntityDto, System.Guid? Etag) : IRequest <SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>;

internal partial class UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler : UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler <UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecondTestEntityOwnedRelationshipOneOrManyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> _entityFactory;

	public UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto, SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityOwnedRelationshipOneOrManyKeyDto?> Handle(UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.SecondTestEntityOwnedRelationshipOneOrManies).LoadAsync(cancellationToken);
		var ownedId = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.String>());
		var entity = parentEntity.SecondTestEntityOwnedRelationshipOneOrManies.SingleOrDefault(x => x.Id == ownedId);
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

		return new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}

public class UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator : AbstractValidator<UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand>
{
    public UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator(ILogger<UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand> logger)
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}