﻿﻿
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto?>;
internal partial class PartialUpdateCountryLocalNamesForCountryCommandHandler: PartialUpdateCountryLocalNamesForCountryCommandHandlerBase
{
	public PartialUpdateCountryLocalNamesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryLocalNamesForCountryCommandHandlerBase: CommandBase<PartialUpdateCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler <PartialUpdateCountryLocalNamesForCountryCommand, CountryLocalNameKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<CountryLocalNameEntity, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> EntityFactory { get; }

	public PartialUpdateCountryLocalNamesForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryLocalNameKeyDto?> Handle(PartialUpdateCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = ClientApi.Domain.CountryLocalNameMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}