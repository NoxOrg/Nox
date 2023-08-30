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

namespace Cryptocash.Application.Commands;

public record PartialUpdateHolidaysCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <HolidaysKeyDto?>;

public class PartialUpdateHolidaysCommandHandler: CommandBase<PartialUpdateHolidaysCommand, Holidays>, IRequestHandler<PartialUpdateHolidaysCommand, HolidaysKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Holidays> EntityMapper { get; }

	public PartialUpdateHolidaysCommandHandler(
		CryptocashDbContext dbContext,
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