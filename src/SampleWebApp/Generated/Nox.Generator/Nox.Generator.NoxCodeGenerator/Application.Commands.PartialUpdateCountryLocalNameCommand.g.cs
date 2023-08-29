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
public record PartialUpdateCountryLocalNameCommand(CountryKeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties) : IRequest <CountryLocalNameKeyDto?>;

public partial class PartialUpdateCountryLocalNameCommandHandler: CommandBase<PartialUpdateCountryLocalNameCommand, CountryLocalName>, IRequestHandler <PartialUpdateCountryLocalNameCommand, CountryLocalNameKeyDto?>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityMapper<CountryLocalName> EntityMapper { get; }

	public PartialUpdateCountryLocalNameCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryLocalName> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CountryLocalNameKeyDto?> Handle(PartialUpdateCountryLocalNameCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,DatabaseNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<CountryLocalName,Text>("Id", request.UpdatedProperties["Id"]);
		var entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CountryLocalName>(), request.UpdatedProperties);
		
		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}