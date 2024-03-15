﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOwnedRelationshipZeroOrManyCommand(System.String keyId, TestEntityOwnedRelationshipZeroOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOwnedRelationshipZeroOrManyKeyDto>;

internal partial class UpdateTestEntityOwnedRelationshipZeroOrManyCommandHandler : UpdateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public UpdateTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<UpdateTestEntityOwnedRelationshipZeroOrManyCommand, TestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler<UpdateTestEntityOwnedRelationshipZeroOrManyCommand, TestEntityOwnedRelationshipZeroOrManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipZeroOrManyKeyDto> Handle(UpdateTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany>()
            .Where(x => x.Id == Dto.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.keyId))
			.Include(e => e.SecEntityOwnedRelZeroOrManies)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityOwnedRelationshipZeroOrManyKeyDto(entity.Id.Value);
	}
}

public class UpdateTestEntityOwnedRelationshipZeroOrManyValidator : AbstractValidator<UpdateTestEntityOwnedRelationshipZeroOrManyCommand>
{
    public UpdateTestEntityOwnedRelationshipZeroOrManyValidator()
    {
		RuleFor(x => x.EntityDto.SecEntityOwnedRelZeroOrManies)
			.ForEach(item => 
			{
				item.Must(owned => owned.Id != null)
					.WithMessage((item, index) => $"SecEntityOwnedRelZeroOrManies[{index}].Id is required.");
			});
    }
}