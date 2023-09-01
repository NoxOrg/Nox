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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record DeleteRefCountryToCountryHolidayCommand(CountryKeyDto EntityKeyDto, CountryHolidayKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class DeleteRefCountryToCountryHolidayCommandHandler: CommandBase<DeleteRefCountryToCountryHolidayCommand, Country>, 
	IRequestHandler <DeleteRefCountryToCountryHolidayCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefCountryToCountryHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefCountryToCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
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
		entity.CountryHolidays.Remove(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}