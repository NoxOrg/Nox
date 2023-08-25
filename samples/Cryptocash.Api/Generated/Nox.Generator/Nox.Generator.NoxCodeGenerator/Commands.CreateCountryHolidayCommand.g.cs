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

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;
public record CreateCountryHolidayCommand(CountryHolidayCreateDto EntityDto) : IRequest<CountryHolidayKeyDto>;

public partial class CreateCountryHolidayCommandHandler: CommandBase<CreateCountryHolidayCommand>, IRequestHandler <CreateCountryHolidayCommand, CountryHolidayKeyDto>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityFactory<CountryHolidayCreateDto,CountryHoliday> EntityFactory { get; }

	public CreateCountryHolidayCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryHolidayCreateDto,CountryHoliday> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CountryHolidayKeyDto> Handle(CreateCountryHolidayCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.CountryHolidays.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryHolidayKeyDto(entityToCreate.Id.Value);
	}
}