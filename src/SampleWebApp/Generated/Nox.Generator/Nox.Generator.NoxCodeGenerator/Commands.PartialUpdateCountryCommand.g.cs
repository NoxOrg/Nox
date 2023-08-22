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

namespace SampleWebApp.Application.Commands;

public record PartialUpdateCountryCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CountryKeyDto?>;

public class PartialUpdateCountryCommandHandler: CommandBase, IRequestHandler<PartialUpdateCountryCommand, CountryKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<Country> EntityMapper { get; }

	public PartialUpdateCountryCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Country> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryKeyDto?> Handle(PartialUpdateCountryCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<Country,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Country>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryKeyDto(entity.Id.Value);
	}
}