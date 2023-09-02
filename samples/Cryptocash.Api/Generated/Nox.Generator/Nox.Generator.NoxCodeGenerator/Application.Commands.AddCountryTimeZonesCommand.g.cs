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
using CountryTimeZones = Cryptocash.Domain.CountryTimeZones;

namespace Cryptocash.Application.Commands;
public record AddCountryTimeZonesCommand(CountryKeyDto ParentKeyDto, CountryTimeZonesCreateDto EntityDto) : IRequest <CountryTimeZonesKeyDto?>;

public partial class AddCountryTimeZonesCommandHandler: CommandBase<AddCountryTimeZonesCommand, CountryTimeZones>, IRequestHandler <AddCountryTimeZonesCommand, CountryTimeZonesKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CountryTimeZonesCreateDto,CountryTimeZones> EntityFactory { get; }

	public AddCountryTimeZonesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryTimeZonesCreateDto,CountryTimeZones> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<CountryTimeZonesKeyDto?> Handle(AddCountryTimeZonesCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = EntityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.CountryTimeZones.Add(entity);

		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryTimeZonesKeyDto(entity.Id.Value);
	}
}