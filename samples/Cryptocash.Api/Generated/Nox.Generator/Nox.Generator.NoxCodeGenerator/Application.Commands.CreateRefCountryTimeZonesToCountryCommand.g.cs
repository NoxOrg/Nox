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
public record CreateRefCountryTimeZonesToCountryCommand(CountryTimeZonesKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCountryTimeZonesToCountryCommandHandler: CommandBase<CreateRefCountryTimeZonesToCountryCommand, CountryTimeZones>, 
	IRequestHandler <CreateRefCountryTimeZonesToCountryCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefCountryTimeZonesToCountryCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefCountryTimeZonesToCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CountryTimeZones,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.CountryTimeZones.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.RelatedEntityKeyDto.keyId);

		var relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}		
		entity.Countries.Add(relatedEntity);

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}