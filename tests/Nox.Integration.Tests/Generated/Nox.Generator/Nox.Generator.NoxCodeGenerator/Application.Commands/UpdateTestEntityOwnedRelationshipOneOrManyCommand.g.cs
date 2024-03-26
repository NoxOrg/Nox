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
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOwnedRelationshipOneOrManyCommand(System.String keyId, TestEntityOwnedRelationshipOneOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOwnedRelationshipOneOrManyKeyDto>;

internal partial class UpdateTestEntityOwnedRelationshipOneOrManyCommandHandler : UpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public UpdateTestEntityOwnedRelationshipOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<UpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyEntity>, IRequestHandler<UpdateTestEntityOwnedRelationshipOneOrManyCommand, TestEntityOwnedRelationshipOneOrManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOwnedRelationshipOneOrManyKeyDto> Handle(UpdateTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany>()
            .Where(x => x.Id == Dto.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.keyId))
			.Include(e => e.SecEntityOwnedRelOneOrManies)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipOneOrMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityOwnedRelationshipOneOrManyKeyDto(entity.Id.Value);
	}
}

public class UpdateTestEntityOwnedRelationshipOneOrManyValidator : AbstractValidator<UpdateTestEntityOwnedRelationshipOneOrManyCommand>
{
    public UpdateTestEntityOwnedRelationshipOneOrManyValidator()
    {
		RuleFor(x => x.EntityDto.SecEntityOwnedRelOneOrManies)
			.ForEach(item => 
			{
				item.Must(owned => owned.Id != null)
					.WithMessage((item, index) => $"SecEntityOwnedRelOneOrManies[{index}].Id is required.");
			});
    }
}