﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityExactlyOneCommand(System.String keyId, SecondTestEntityExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityExactlyOneKeyDto>;

internal partial class UpdateSecondTestEntityExactlyOneCommandHandler : UpdateSecondTestEntityExactlyOneCommandHandlerBase
{
	public UpdateSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityExactlyOneCommandHandlerBase : CommandBase<UpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneEntity>, IRequestHandler<UpdateSecondTestEntityExactlyOneCommand, SecondTestEntityExactlyOneKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> _entityFactory;

	protected UpdateSecondTestEntityExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityExactlyOneEntity, SecondTestEntityExactlyOneCreateDto, SecondTestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityExactlyOneKeyDto> Handle(UpdateSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return new SecondTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}