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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityExactlyOneCommand(System.String keyId, TestEntityExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityExactlyOneKeyDto>;

internal partial class UpdateTestEntityExactlyOneCommandHandler : UpdateTestEntityExactlyOneCommandHandlerBase
{
	public UpdateTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityExactlyOneCommand, TestEntityExactlyOneEntity>, IRequestHandler<UpdateTestEntityExactlyOneCommand, TestEntityExactlyOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityExactlyOneEntity, TestEntityExactlyOneCreateDto, TestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityExactlyOneKeyDto> Handle(UpdateTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityExactlyOne>()
            .Where(x => x.Id == Dto.TestEntityExactlyOneMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		Repository.Update(entity);
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}