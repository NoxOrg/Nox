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

namespace Cryptocash.Application.Commands;
public record CreateCountryHolidayCommand(CountryHolidayCreateDto EntityDto) : IRequest<CountryHolidayKeyDto>;

public partial class CreateCountryHolidayCommandHandler: CommandBase<CreateCountryHolidayCommand,CountryHoliday>, IRequestHandler <CreateCountryHolidayCommand, CountryHolidayKeyDto>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CountryHolidayCreateDto,CountryHoliday> EntityFactory { get; }

	public CreateCountryHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryHolidayCreateDto,CountryHoliday> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CountryHolidayKeyDto> Handle(CreateCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.CountryHolidays.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryHolidayKeyDto(entityToCreate.Id.Value);
	}
}