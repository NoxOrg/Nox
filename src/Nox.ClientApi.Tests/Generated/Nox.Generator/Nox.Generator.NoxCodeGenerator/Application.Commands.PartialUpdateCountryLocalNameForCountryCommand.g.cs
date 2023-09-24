﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;
public record PartialUpdateCountryLocalNameForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto?>;
public partial class PartialUpdateCountryLocalNameForCountryCommandHandler: PartialUpdateCountryLocalNameForCountryCommandHandlerBase
{
	public PartialUpdateCountryLocalNameForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory) : base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}
public abstract class PartialUpdateCountryLocalNameForCountryCommandHandlerBase: CommandBase<PartialUpdateCountryLocalNameForCountryCommand, CountryLocalName>, IRequestHandler <PartialUpdateCountryLocalNameForCountryCommand, CountryLocalNameKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> EntityFactory { get; }

	public PartialUpdateCountryLocalNameForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryLocalNameKeyDto?> Handle(PartialUpdateCountryLocalNameForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<CountryLocalName,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryShortNames.SingleOrDefault(x => x.Id == ownedId);	
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}