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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOneOrManyToZeroOrOneCommand(System.String keyId, TestEntityOneOrManyToZeroOrOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOneOrManyToZeroOrOneKeyDto>;

internal partial class UpdateTestEntityOneOrManyToZeroOrOneCommandHandler : UpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityOneOrManyToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler<UpdateTestEntityOneOrManyToZeroOrOneCommand, TestEntityOneOrManyToZeroOrOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToZeroOrOneEntity, TestEntityOneOrManyToZeroOrOneCreateDto, TestEntityOneOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToZeroOrOneKeyDto> Handle(UpdateTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne>()
            .Where(x => x.Id == Dto.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityOneOrManyToZeroOrOneKeyDto(entity.Id.Value);
	}
}