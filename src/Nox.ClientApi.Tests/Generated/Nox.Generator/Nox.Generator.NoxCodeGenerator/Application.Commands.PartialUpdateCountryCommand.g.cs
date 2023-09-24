﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Country = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public record PartialUpdateCountryCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CountryKeyDto?>;

public class PartialUpdateCountryCommandHandler: PartialUpdateCountryCommandHandlerBase
{
	public PartialUpdateCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
public class PartialUpdateCountryCommandHandlerBase: CommandBase<PartialUpdateCountryCommand, Country>, IRequestHandler<PartialUpdateCountryCommand, CountryKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> EntityFactory { get; }

	public PartialUpdateCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryKeyDto?> Handle(PartialUpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryKeyDto(entity.Id.Value);
	}
}