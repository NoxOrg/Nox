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
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryTimeZoneEntity = ClientApi.Domain.CountryTimeZone;

namespace ClientApi.Application.Commands;
public partial record CreateCountryTimeZonesForCountryCommand(CountryKeyDto ParentKeyDto, CountryTimeZoneUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryTimeZoneKeyDto>;

internal partial class CreateCountryTimeZonesForCountryCommandHandler : CreateCountryTimeZonesForCountryCommandHandlerBase
{
	public CreateCountryTimeZonesForCountryCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateCountryTimeZonesForCountryCommandHandlerBase : CommandBase<CreateCountryTimeZonesForCountryCommand, CountryTimeZoneEntity>, IRequestHandler<CreateCountryTimeZonesForCountryCommand, CountryTimeZoneKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> RntityFactory;
	
	protected CreateCountryTimeZonesForCountryCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<CountryTimeZoneKeyDto?> Handle(CreateCountryTimeZonesForCountryCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<Country> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToCountryTimeZones(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.SetStateModified(parentEntity);		
		await Repository.SaveChangesAsync();

		return new CountryTimeZoneKeyDto(entity.Id.Value);
	}
}

public class CreateCountryTimeZonesForCountryValidator : AbstractValidator<CreateCountryTimeZonesForCountryCommand>
{
    public CreateCountryTimeZonesForCountryValidator()
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}