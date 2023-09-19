﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public record PartialUpdateLandLordCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <LandLordKeyDto?>;

public class PartialUpdateLandLordCommandHandler: PartialUpdateLandLordCommandHandlerBase
{
	public PartialUpdateLandLordCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<LandLord> entityMapper): base(dbContext,noxSolution, serviceProvider, entityMapper)
	{
	}
}
public class PartialUpdateLandLordCommandHandlerBase: CommandBase<PartialUpdateLandLordCommand, LandLord>, IRequestHandler<PartialUpdateLandLordCommand, LandLordKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<LandLord> EntityMapper { get; }

	public PartialUpdateLandLordCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<LandLord> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public virtual async Task<LandLordKeyDto?> Handle(PartialUpdateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<LandLord,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<LandLord>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new LandLordKeyDto(entity.Id.Value);
	}
}