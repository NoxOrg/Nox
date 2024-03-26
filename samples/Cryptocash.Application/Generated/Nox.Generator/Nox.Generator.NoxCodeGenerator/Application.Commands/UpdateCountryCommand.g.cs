﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public partial record UpdateCountryCommand(System.String keyId, CountryUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryKeyDto>;

internal partial class UpdateCountryCommandHandler : UpdateCountryCommandHandlerBase
{
	public UpdateCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryCommandHandlerBase : CommandBase<UpdateCountryCommand, CountryEntity>, IRequestHandler<UpdateCountryCommand, CountryKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> EntityFactory { get; }
	protected UpdateCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryKeyDto> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Cryptocash.Domain.Country>()
            .Where(x => x.Id == Dto.CountryMetadata.CreateId(request.keyId))
			.Include(e => e.CountryTimeZones)
			.Include(e => e.Holidays)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new CountryKeyDto(entity.Id.Value);
	}
}

public class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryValidator()
    {
    }
}