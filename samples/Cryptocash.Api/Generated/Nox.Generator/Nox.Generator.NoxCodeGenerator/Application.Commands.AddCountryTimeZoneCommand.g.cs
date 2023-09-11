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
using CountryTimeZone = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Commands;
public record AddCountryTimeZoneCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneCreateDto EntityDto) : IRequest <CountryTimeZoneKeyDto?>;

public partial class AddCountryTimeZoneCommandHandler: CommandBase<AddCountryTimeZoneCommand, CountryTimeZone>, IRequestHandler <AddCountryTimeZoneCommand, CountryTimeZoneKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CountryTimeZone,CountryTimeZoneCreateDto> _entityFactory;

	public AddCountryTimeZoneCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryTimeZone,CountryTimeZoneCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public async Task<CountryTimeZoneKeyDto?> Handle(AddCountryTimeZoneCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.CountryTimeZones.Add(entity);

		OnCompleted(request, entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}