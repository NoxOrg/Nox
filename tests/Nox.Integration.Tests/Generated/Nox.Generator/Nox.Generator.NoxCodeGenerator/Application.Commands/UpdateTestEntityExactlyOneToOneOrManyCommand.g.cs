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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityExactlyOneToOneOrManyCommand(System.String keyId, TestEntityExactlyOneToOneOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityExactlyOneToOneOrManyKeyDto>;

internal partial class UpdateTestEntityExactlyOneToOneOrManyCommandHandler : UpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase
{
	public UpdateTestEntityExactlyOneToOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase : CommandBase<UpdateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyEntity>, IRequestHandler<UpdateTestEntityExactlyOneToOneOrManyCommand, TestEntityExactlyOneToOneOrManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityExactlyOneToOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToOneOrManyKeyDto> Handle(UpdateTestEntityExactlyOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestEntityExactlyOneToOneOrMany>()
            .Where(x => x.Id == Dto.TestEntityExactlyOneToOneOrManyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityExactlyOneToOneOrManyKeyDto(entity.Id.Value);
	}
}