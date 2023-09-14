﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;
public record PartialUpdateHolidayCommand(CountryKeyDto ParentKeyDto, HolidayKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <HolidayKeyDto?>;

public partial class PartialUpdateHolidayCommandHandler: CommandBase<PartialUpdateHolidayCommand, Holiday>, IRequestHandler <PartialUpdateHolidayCommand, HolidayKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<Holiday> EntityMapper { get; }

	public PartialUpdateHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Holiday> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<HolidayKeyDto?> Handle(PartialUpdateHolidayCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<Holiday,AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.Holidays.SingleOrDefault(x => x.Id == ownedId);	
		if (entity == null)
		{
			return null;
		}

		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Holiday>(), request.UpdatedProperties);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new HolidayKeyDto(entity.Id.Value);
	}
}