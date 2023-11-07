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
public partial record PartialUpdateHolidayForCountryCommand(CountryKeyDto ParentKeyDto, HolidayKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <HolidayKeyDto?>;
internal partial class PartialUpdateHolidayForCountryCommandHandler: PartialUpdateHolidayForCountryCommandHandlerBase
{
	public PartialUpdateHolidayForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayCreateDto, HolidayUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateHolidayForCountryCommandHandlerBase: CommandBase<PartialUpdateHolidayForCountryCommand, HolidayEntity>, IRequestHandler <PartialUpdateHolidayForCountryCommand, HolidayKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<HolidayEntity, HolidayCreateDto, HolidayUpdateDto> EntityFactory { get; }

	public PartialUpdateHolidayForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayCreateDto, HolidayUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<HolidayKeyDto?> Handle(PartialUpdateHolidayForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = Cryptocash.Domain.HolidayMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryOwnedHolidays.SingleOrDefault(x => x.Id == ownedId);
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

		return new HolidayKeyDto(entity.Id.Value);
	}
}