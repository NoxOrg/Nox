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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityZeroOrManyToZeroOrOneCommand(System.String keyId, TestEntityZeroOrManyToZeroOrOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityZeroOrManyToZeroOrOneKeyDto>;

internal partial class UpdateTestEntityZeroOrManyToZeroOrOneCommandHandler : UpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase
{
	public UpdateTestEntityZeroOrManyToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneEntity>, IRequestHandler<UpdateTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrManyToZeroOrOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrManyToZeroOrOneKeyDto> Handle(UpdateTestEntityZeroOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestEntityZeroOrManyToZeroOrOne>()
            .Where(x => x.Id == Dto.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityZeroOrManyToZeroOrOneKeyDto(entity.Id.Value);
	}
}