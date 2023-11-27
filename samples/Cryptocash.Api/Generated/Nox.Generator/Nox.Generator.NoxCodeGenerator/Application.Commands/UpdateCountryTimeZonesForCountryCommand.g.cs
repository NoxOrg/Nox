﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryTimeZoneEntity = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Commands;

public partial record UpdateCountryTimeZonesForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneUpsertDto EntityDto, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto?>;

internal partial class UpdateCountryTimeZonesForCountryCommandHandler : UpdateCountryTimeZonesForCountryCommandHandlerBase
{
	public UpdateCountryTimeZonesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryTimeZonesForCountryCommandHandlerBase : CommandBase<UpdateCountryTimeZonesForCountryCommand, CountryTimeZoneEntity>, IRequestHandler <UpdateCountryTimeZonesForCountryCommand, CountryTimeZoneKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> _entityFactory;

	public UpdateCountryTimeZonesForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryTimeZoneKeyDto?> Handle(UpdateCountryTimeZonesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.CountryTimeZones).LoadAsync(cancellationToken);
		var ownedId = Cryptocash.Domain.CountryTimeZoneMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
		var entity = parentEntity.CountryTimeZones.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}

public class UpdateCountryTimeZonesForCountryValidator : AbstractValidator<UpdateCountryTimeZonesForCountryCommand>
{
    public UpdateCountryTimeZonesForCountryValidator(ILogger<UpdateCountryTimeZonesForCountryCommand> logger)
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}