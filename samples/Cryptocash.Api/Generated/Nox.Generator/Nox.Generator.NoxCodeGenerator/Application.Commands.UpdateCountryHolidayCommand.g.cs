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
using CountryHoliday = Cryptocash.Domain.CountryHoliday;

namespace Cryptocash.Application.Commands;

public record UpdateCountryHolidayCommand(System.Int64 keyId, CountryHolidayUpdateDto EntityDto) : IRequest<CountryHolidayKeyDto?>;

public class UpdateCountryHolidayCommandHandler: CommandBase<UpdateCountryHolidayCommand, CountryHoliday>, IRequestHandler<UpdateCountryHolidayCommand, CountryHolidayKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CountryHoliday> EntityMapper { get; }

	public UpdateCountryHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryHoliday> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CountryHolidayKeyDto?> Handle(UpdateCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CountryHoliday,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.CountryHolidays.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryHoliday>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryHolidayKeyDto(entity.Id.Value);
	}
}