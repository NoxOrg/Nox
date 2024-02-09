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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityOneOrManyToExactlyOneCommand(System.String keyId, TestEntityOneOrManyToExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityOneOrManyToExactlyOneKeyDto>;

internal partial class UpdateTestEntityOneOrManyToExactlyOneCommandHandler : UpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase
{
	public UpdateTestEntityOneOrManyToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneEntity>, IRequestHandler<UpdateTestEntityOneOrManyToExactlyOneCommand, TestEntityOneOrManyToExactlyOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityOneOrManyToExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityOneOrManyToExactlyOneKeyDto> Handle(UpdateTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne>()
            .Where(x => x.Id == Dto.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToExactlyOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityOneOrManyToExactlyOneKeyDto(entity.Id.Value);
	}
}