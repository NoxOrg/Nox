﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record UpdateLandLordCommand(System.Int64 keyId, LandLordUpdateDto EntityDto) : IRequest<LandLordKeyDto?>;

public class UpdateLandLordCommandHandler: CommandBase<UpdateLandLordCommand, LandLord>, IRequestHandler<UpdateLandLordCommand, LandLordKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<LandLord> EntityMapper { get; }

	public UpdateLandLordCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<LandLord> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<LandLordKeyDto?> Handle(UpdateLandLordCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<LandLord,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.LandLords.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<LandLord>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new LandLordKeyDto(entity.Id.Value);
	}
}