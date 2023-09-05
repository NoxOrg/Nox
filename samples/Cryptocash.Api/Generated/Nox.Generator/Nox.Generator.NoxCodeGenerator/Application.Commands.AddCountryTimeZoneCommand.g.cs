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
	public CryptocashDbContext DbContext { get; }

	public AddCountryTimeZoneCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;		
	}

	public async Task<CountryTimeZoneKeyDto?> Handle(AddCountryTimeZoneCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = request.EntityDto.ToEntity();
		
		parentEntity.CountryTimeZones.Add(entity);

		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}