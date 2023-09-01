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

public record PartialUpdateCountryHolidayCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CountryHolidayKeyDto?>;

public class PartialUpdateCountryHolidayCommandHandler: CommandBase<PartialUpdateCountryHolidayCommand, CountryHoliday>, IRequestHandler<PartialUpdateCountryHolidayCommand, CountryHolidayKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CountryHoliday> EntityMapper { get; }

	public PartialUpdateCountryHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryHoliday> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryHolidayKeyDto?> Handle(PartialUpdateCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CountryHoliday,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CountryHolidays.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CountryHoliday>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryHolidayKeyDto(entity.Id.Value);
	}
}