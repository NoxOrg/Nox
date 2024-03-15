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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityExactlyOneToZeroOrManyCommand(System.String keyId, TestEntityExactlyOneToZeroOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityExactlyOneToZeroOrManyKeyDto>;

internal partial class UpdateTestEntityExactlyOneToZeroOrManyCommandHandler : UpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase
{
	public UpdateTestEntityExactlyOneToZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase : CommandBase<UpdateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyEntity>, IRequestHandler<UpdateTestEntityExactlyOneToZeroOrManyCommand, TestEntityExactlyOneToZeroOrManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneToZeroOrManyKeyDto> Handle(UpdateTestEntityExactlyOneToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany>()
            .Where(x => x.Id == Dto.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityExactlyOneToZeroOrManyKeyDto(entity.Id.Value);
	}
}