﻿﻿// Generated

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
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using AProductEntity = Cryptocash.Domain.AProduct;

namespace Cryptocash.Application.Commands;

public partial record UpdateAProductCommand(System.Int64 keyId, AProductUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<AProductKeyDto?>;

internal partial class UpdateAProductCommandHandler : UpdateAProductCommandHandlerBase
{
	public UpdateAProductCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateAProductCommandHandlerBase : CommandBase<UpdateAProductCommand, AProductEntity>, IRequestHandler<UpdateAProductCommand, AProductKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> _entityFactory;

	protected UpdateAProductCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<AProductKeyDto?> Handle(UpdateAProductCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.AProductMetadata.CreateId(request.keyId);

		var entity = await DbContext.AProducts.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new AProductKeyDto(entity.Id.Value);
	}
}