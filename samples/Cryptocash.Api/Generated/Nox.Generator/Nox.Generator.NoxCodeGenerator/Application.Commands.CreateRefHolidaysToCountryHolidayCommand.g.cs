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
public record CreateRefHolidaysToCountryHolidayCommand(HolidaysKeyDto EntityKeyDto, CountryHolidayKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefHolidaysToCountryHolidayCommandHandler: CommandBase<CreateRefHolidaysToCountryHolidayCommand, Holidays>, 
	IRequestHandler <CreateRefHolidaysToCountryHolidayCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefHolidaysToCountryHolidayCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefHolidaysToCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Holidays,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Holidays.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CountryHoliday,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.CountryHolidays.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}		
		entity.CountryHolidays.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}