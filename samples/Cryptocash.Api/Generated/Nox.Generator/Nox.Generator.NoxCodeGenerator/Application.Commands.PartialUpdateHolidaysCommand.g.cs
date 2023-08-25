﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateHolidaysCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <HolidaysKeyDto?>;

public class PartialUpdateHolidaysCommandHandler: CommandBase<PartialUpdateHolidaysCommand, Holidays>, IRequestHandler<PartialUpdateHolidaysCommand, HolidaysKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<Holidays> EntityMapper { get; }

	public PartialUpdateHolidaysCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Holidays> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<HolidaysKeyDto?> Handle(PartialUpdateHolidaysCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Holidays,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Holidays.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Holidays>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new HolidaysKeyDto(entity.Id.Value);
	}
}