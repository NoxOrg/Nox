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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityZeroOrOneToOneOrManyCommand(System.String keyId, TestEntityZeroOrOneToOneOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityZeroOrOneToOneOrManyKeyDto>;

internal partial class UpdateTestEntityZeroOrOneToOneOrManyCommandHandler : UpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase
{
	public UpdateTestEntityZeroOrOneToOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler<UpdateTestEntityZeroOrOneToOneOrManyCommand, TestEntityZeroOrOneToOneOrManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityZeroOrOneToOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToOneOrManyEntity, TestEntityZeroOrOneToOneOrManyCreateDto, TestEntityZeroOrOneToOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToOneOrManyKeyDto> Handle(UpdateTestEntityZeroOrOneToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany>()
            .Where(x => x.Id == Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		Repository.Update(entity);
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityZeroOrOneToOneOrManyKeyDto(entity.Id.Value);
	}
}