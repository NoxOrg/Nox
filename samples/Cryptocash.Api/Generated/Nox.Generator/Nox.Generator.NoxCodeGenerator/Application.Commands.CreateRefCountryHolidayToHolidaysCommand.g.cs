﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateRefCountryHolidayToHolidaysCommand(CountryHolidayKeyDto EntityKeyDto, HolidaysKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCountryHolidayToHolidaysCommandHandler: CommandBase<CreateRefCountryHolidayToHolidaysCommand, CountryHoliday>, 
	IRequestHandler <CreateRefCountryHolidayToHolidaysCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefCountryHolidayToHolidaysCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefCountryHolidayToHolidaysCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CountryHoliday,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.CountryHolidays.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Holidays,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.Holidays.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}		
		entity.Holidays.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}