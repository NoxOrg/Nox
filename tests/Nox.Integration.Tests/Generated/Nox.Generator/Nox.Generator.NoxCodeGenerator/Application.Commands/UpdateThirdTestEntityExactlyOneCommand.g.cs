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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record UpdateThirdTestEntityExactlyOneCommand(System.String keyId, ThirdTestEntityExactlyOneUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ThirdTestEntityExactlyOneKeyDto>;

internal partial class UpdateThirdTestEntityExactlyOneCommandHandler : UpdateThirdTestEntityExactlyOneCommandHandlerBase
{
	public UpdateThirdTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateThirdTestEntityExactlyOneCommandHandlerBase : CommandBase<UpdateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneEntity>, IRequestHandler<UpdateThirdTestEntityExactlyOneCommand, ThirdTestEntityExactlyOneKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> _entityFactory;
	protected UpdateThirdTestEntityExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityExactlyOneEntity, ThirdTestEntityExactlyOneCreateDto, ThirdTestEntityExactlyOneUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityExactlyOneKeyDto> Handle(UpdateThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityExactlyOne",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new ThirdTestEntityExactlyOneKeyDto(entity.Id.Value);
	}
}