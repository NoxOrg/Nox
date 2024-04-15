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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityExactlyOneCommand(System.String keyId, SecondTestEntityExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityExactlyOneKeyDto>;

internal partial class UpdateSecondTestEntityExactlyOneCommandHandler : UpdateSecondTestEntityExactlyOneCommandHandlerBase
{
	public UpdateSecondTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityExactlyOneCommandHandlerBase : CommandBase<UpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneEntity>, IRequestHandler<UpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> EntityFactory { get; }
	protected UpdateSecondTestEntityExactlyOneCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto> Handle(UpdateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.SecondTestEntityExactlyOne>()
            .Where(x => x.Id == Dto.SecondTestEntityExactlyOneMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		Repository.Update(entity);
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new SecondTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}