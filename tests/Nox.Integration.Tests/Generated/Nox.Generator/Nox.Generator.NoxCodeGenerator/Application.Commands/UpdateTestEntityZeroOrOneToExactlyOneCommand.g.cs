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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityZeroOrOneToExactlyOneCommand(System.String keyId, TestEntityZeroOrOneToExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityZeroOrOneToExactlyOneKeyDto>;

internal partial class UpdateTestEntityZeroOrOneToExactlyOneCommandHandler : UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase
{
	public UpdateTestEntityZeroOrOneToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase : CommandBase<UpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneEntity>, IRequestHandler<UpdateTestEntityZeroOrOneToExactlyOneCommand, TestEntityZeroOrOneToExactlyOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityZeroOrOneToExactlyOneKeyDto> Handle(UpdateTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne>()
            .Where(x => x.Id == Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityZeroOrOneToExactlyOneKeyDto(entity.Id.Value);
	}
}