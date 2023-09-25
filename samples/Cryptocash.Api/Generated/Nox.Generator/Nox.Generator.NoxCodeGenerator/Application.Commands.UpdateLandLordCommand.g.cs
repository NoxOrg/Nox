﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public record UpdateLandLordCommand(System.Int64 keyId, LandLordUpdateDto EntityDto, System.Guid? Etag) : IRequest<LandLordKeyDto?>;

internal partial class UpdateLandLordCommandHandler: UpdateLandLordCommandHandlerBase
{
	public UpdateLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

internal abstract class UpdateLandLordCommandHandlerBase: CommandBase<UpdateLandLordCommand, LandLord>, IRequestHandler<UpdateLandLordCommand, LandLordKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> _entityFactory;

	public UpdateLandLordCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<LandLordKeyDto?> Handle(UpdateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<LandLord,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new LandLordKeyDto(entity.Id.Value);
	}
}