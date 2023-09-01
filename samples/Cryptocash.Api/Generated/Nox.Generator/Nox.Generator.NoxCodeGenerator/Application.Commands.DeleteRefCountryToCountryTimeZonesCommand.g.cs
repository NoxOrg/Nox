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
public record DeleteRefCountryToCountryTimeZonesCommand(CountryKeyDto EntityKeyDto, CountryTimeZonesKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class DeleteRefCountryToCountryTimeZonesCommandHandler: CommandBase<DeleteRefCountryToCountryTimeZonesCommand, Country>, 
	IRequestHandler <DeleteRefCountryToCountryTimeZonesCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteRefCountryToCountryTimeZonesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteRefCountryToCountryTimeZonesCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CountryTimeZones,DatabaseNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.CountryTimeZones.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		entity.CountryTimeZones.Remove(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}