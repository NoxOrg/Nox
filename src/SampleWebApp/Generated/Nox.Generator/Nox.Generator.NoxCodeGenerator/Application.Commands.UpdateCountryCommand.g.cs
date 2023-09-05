﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;
using Country = SampleWebApp.Domain.Country;

namespace SampleWebApp.Application.Commands;

public record UpdateCountryCommand(System.Int64 keyId, CountryUpdateDto EntityDto) : IRequest<CountryKeyDto?>;

public class UpdateCountryCommandHandler: CommandBase<UpdateCountryCommand, Country>, IRequestHandler<UpdateCountryCommand, CountryKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<Country> EntityMapper { get; }
	public IEntityMapper<CountryLocalName> CountryLocalNameEntityMapper { get; }

	public UpdateCountryCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,	
			IEntityMapper<CountryLocalName> entityMapperCountryLocalName,
		IEntityMapper<Country> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;	
		CountryLocalNameEntityMapper = entityMapperCountryLocalName;
		EntityMapper = entityMapper;
	}
	
	public async Task<CountryKeyDto?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Country>(), request.EntityDto);
		foreach(var ownedEntity in request.EntityDto.CountryLocalNames)
		{
			UpdateCountryLocalName(entity, ownedEntity);
		}

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryKeyDto(entity.Id.Value);
	}
	private void UpdateCountryLocalName(Country parent, CountryLocalNameDto child)
	{
		var ownedId = CreateNoxTypeForKey<CountryLocalName,Text>("Id", child.Id);

		var entity = parent.CountryLocalNames.SingleOrDefault(x =>
			x.Id.Equals(ownedId) &&
			true);
		if (entity == null)
		{
			return;
		}

		CountryLocalNameEntityMapper.MapToEntity(entity, GetEntityDefinition<CountryLocalName>(), child);		
	}
}