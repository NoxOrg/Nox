﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryHoliday = Cryptocash.Domain.CountryHoliday;

namespace Cryptocash.Application.Commands;
public record CreateCountryHolidayCommand(CountryHolidayCreateDto EntityDto) : IRequest<CountryHolidayKeyDto>;

public partial class CreateCountryHolidayCommandHandler: CommandBase<CreateCountryHolidayCommand,CountryHoliday>, IRequestHandler <CreateCountryHolidayCommand, CountryHolidayKeyDto>
{
	public CryptocashDbContext DbContext { get; }

	public CreateCountryHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<CountryHolidayKeyDto> Handle(CreateCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = request.EntityDto.ToEntity();
	
		OnCompleted(entityToCreate);
		DbContext.CountryHolidays.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryHolidayKeyDto(entityToCreate.Id.Value);
	}
}