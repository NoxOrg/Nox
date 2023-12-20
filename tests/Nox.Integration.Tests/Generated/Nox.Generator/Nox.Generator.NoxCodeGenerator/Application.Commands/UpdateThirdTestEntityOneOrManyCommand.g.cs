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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateThirdTestEntityOneOrManyCommand(System.String keyId, ThirdTestEntityOneOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ThirdTestEntityOneOrManyKeyDto>;

internal partial class UpdateThirdTestEntityOneOrManyCommandHandler : UpdateThirdTestEntityOneOrManyCommandHandlerBase
{
	public UpdateThirdTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateThirdTestEntityOneOrManyCommandHandlerBase : CommandBase<UpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyEntity>, IRequestHandler<UpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> _entityFactory;

	protected UpdateThirdTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityOneOrManyKeyDto> Handle(UpdateThirdTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await DbContext.ThirdTestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new ThirdTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}