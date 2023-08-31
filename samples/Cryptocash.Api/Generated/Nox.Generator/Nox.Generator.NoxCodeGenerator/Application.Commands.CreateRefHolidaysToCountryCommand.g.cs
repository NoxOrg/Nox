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
public record CreateRefHolidaysToCountryCommand(HolidaysKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefHolidaysToCountryCommandHandler: CommandBase<CreateRefHolidaysToCountryCommand, Holidays>, 
	IRequestHandler <CreateRefHolidaysToCountryCommand, bool>
{
	public CryptocashApiDbContext DbContext { get; }

	public CreateRefHolidaysToCountryCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefHolidaysToCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Holidays,DatabaseNumber>("Id", request.EntityKeyDto.keyId);

		var entity = await DbContext.Holidays.FindAsync(keyId);
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
		entity.Country = relatedEntity;
		

		OnCompleted(entity);
	
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}