﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record UpdateCountryCommand(System.Int64 keyId, CountryUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryKeyDto?>;

internal partial class UpdateCountryCommandHandler : UpdateCountryCommandHandlerBase
{
	public UpdateCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateCountryCommandHandlerBase : CommandBase<UpdateCountryCommand, CountryEntity>, IRequestHandler<UpdateCountryCommand, CountryKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> _entityFactory;

	protected UpdateCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryKeyDto?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.keyId);

		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		await DbContext.Entry(entity).Collection(x => x.CountryLocalNames).LoadAsync();
		await DbContext.Entry(entity).Reference(x => x.CountryBarCode).LoadAsync();
		await DbContext.Entry(entity).Collection(x => x.CountryTimeZones).LoadAsync();
		await DbContext.Entry(entity).Collection(x => x.Holidays).LoadAsync();

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryKeyDto(entity.Id.Value);
	}
}

public class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryValidator()
    {
		RuleFor(x => x.EntityDto.CountryTimeZones)
			.ForEach(item => 
			{
				item.Must(owned => owned.Id != null)
					.WithMessage((item, index) => $"CountryTimeZones[{index}].Id is required.");
			}); 
    }
}