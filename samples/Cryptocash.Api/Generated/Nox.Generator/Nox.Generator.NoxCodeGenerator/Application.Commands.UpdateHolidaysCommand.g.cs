﻿﻿// Generated

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

namespace Cryptocash.Application.Commands;

public record UpdateHolidaysCommand(System.Int64 keyId, HolidaysUpdateDto EntityDto) : IRequest<HolidaysKeyDto?>;

public class UpdateHolidaysCommandHandler: CommandBase<UpdateHolidaysCommand, Holidays>, IRequestHandler<UpdateHolidaysCommand, HolidaysKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Holidays> EntityMapper { get; }

	public UpdateHolidaysCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Holidays> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<HolidaysKeyDto?> Handle(UpdateHolidaysCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Holidays,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.Holidays.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Holidays>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new HolidaysKeyDto(entity.Id.Value);
	}
}