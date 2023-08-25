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

public record PartialUpdateCountryHolidayCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CountryHolidayKeyDto?>;

public class PartialUpdateCountryHolidayCommandHandler: CommandBase<PartialUpdateCountryHolidayCommand>, IRequestHandler<PartialUpdateCountryHolidayCommand, CountryHolidayKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<CountryHoliday> EntityMapper { get; }

	public PartialUpdateCountryHolidayCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryHoliday> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryHolidayKeyDto?> Handle(PartialUpdateCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<CountryHoliday,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CountryHolidays.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CountryHoliday>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryHolidayKeyDto(entity.Id.Value);
	}
}