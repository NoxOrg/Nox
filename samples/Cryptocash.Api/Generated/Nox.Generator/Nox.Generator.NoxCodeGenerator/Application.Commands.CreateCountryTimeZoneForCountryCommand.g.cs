﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CountryTimeZone = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Commands;
public record CreateCountryTimeZoneForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneCreateDto EntityDto, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto?>;

public partial class CreateCountryTimeZoneForCountryCommandHandler: CreateCountryTimeZoneForCountryCommandHandlerBase
{
	public CreateCountryTimeZoneForCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution, entityFactory, serviceProvider)
	{
	}
}
public abstract class CreateCountryTimeZoneForCountryCommandHandlerBase: CommandBase<CreateCountryTimeZoneForCountryCommand, CountryTimeZone>, IRequestHandler<CreateCountryTimeZoneForCountryCommand, CountryTimeZoneKeyDto?>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> _entityFactory;

	public CreateCountryTimeZoneForCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<CountryTimeZoneKeyDto?> Handle(CreateCountryTimeZoneForCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.CountryCode2>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CountryOwnedTimeZones.Add(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}