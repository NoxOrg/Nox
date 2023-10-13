﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using HolidayEntity = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Commands;
public record CreateHolidayForCountryCommand(CountryKeyDto ParentKeyDto, HolidayCreateDto EntityDto, System.Guid? Etag) : IRequest <HolidayKeyDto?>;

internal partial class CreateHolidayForCountryCommandHandler : CreateHolidayForCountryCommandHandlerBase
{
	public CreateHolidayForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayCreateDto, HolidayUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateHolidayForCountryCommandHandlerBase : CommandBase<CreateHolidayForCountryCommand, HolidayEntity>, IRequestHandler<CreateHolidayForCountryCommand, HolidayKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<HolidayEntity, HolidayCreateDto, HolidayUpdateDto> _entityFactory;

	public CreateHolidayForCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<HolidayEntity, HolidayCreateDto, HolidayUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<HolidayKeyDto?> Handle(CreateHolidayForCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CreateRefToCountryOwnedHolidays(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new HolidayKeyDto(entity.Id.Value);
	}
}