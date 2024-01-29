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
using TestEntityWithNuidEntity = TestWebApp.Domain.TestEntityWithNuid;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityWithNuidCommand(System.UInt32 keyId, TestEntityWithNuidUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityWithNuidKeyDto>;

internal partial class UpdateTestEntityWithNuidCommandHandler : UpdateTestEntityWithNuidCommandHandlerBase
{
	public UpdateTestEntityWithNuidCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTestEntityWithNuidCommandHandlerBase : CommandBase<UpdateTestEntityWithNuidCommand, TestEntityWithNuidEntity>, IRequestHandler<UpdateTestEntityWithNuidCommand, TestEntityWithNuidKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> EntityFactory { get; }
	protected UpdateTestEntityWithNuidCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityWithNuidEntity, TestEntityWithNuidCreateDto, TestEntityWithNuidUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TestEntityWithNuidKeyDto> Handle(UpdateTestEntityWithNuidCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestEntityWithNuid>()
            .Where(x => x.Id == Dto.TestEntityWithNuidMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityWithNuid",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TestEntityWithNuidKeyDto(entity.Id.Value);
	}
}