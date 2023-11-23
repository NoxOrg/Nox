﻿
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using HolidayEntity = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Commands;
public partial record UpdateHolidaysForCountryCommand(CountryKeyDto ParentKeyDto, HolidayKeyDto EntityKeyDto, HolidayUpsertDto EntityDto, System.Guid? Etag) : IRequest <HolidayKeyDto?>;

internal partial class UpdateHolidaysForCountryCommandHandler : UpdateHolidaysForCountryCommandHandlerBase
{
	public UpdateHolidaysForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateHolidaysForCountryCommandHandlerBase : CommandBase<UpdateHolidaysForCountryCommand, HolidayEntity>, IRequestHandler <UpdateHolidaysForCountryCommand, HolidayKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> _entityFactory;

	public UpdateHolidaysForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<HolidayKeyDto?> Handle(UpdateHolidaysForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.Holidays).LoadAsync(cancellationToken);
		var ownedId = Cryptocash.Domain.HolidayMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.Holidays.SingleOrDefault(x => x.Id == ownedId);
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

		return new HolidayKeyDto(entity.Id.Value);
	}
}