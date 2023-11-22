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
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;

public partial record UpdateCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameUpsertDto EntityDto, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto?>;

internal partial class UpdateCountryLocalNamesForCountryCommandHandler : UpdateCountryLocalNamesForCountryCommandHandlerBase
{
	public UpdateCountryLocalNamesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateCountryLocalNamesForCountryCommandHandlerBase : CommandBase<UpdateCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler <UpdateCountryLocalNamesForCountryCommand, CountryLocalNameKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> _entityFactory;

	public UpdateCountryLocalNamesForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryLocalNameEntity, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryLocalNameKeyDto?> Handle(UpdateCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = ClientApi.Domain.CountryLocalNameMetadata.CreateId(request.EntityDto.Id.NonNullValue<System.Int64>());
		var entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
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

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}

public class UpdateCountryLocalNamesForCountryValidator : AbstractValidator<UpdateCountryLocalNamesForCountryCommand>
{
    public UpdateCountryLocalNamesForCountryValidator(ILogger<UpdateCountryLocalNamesForCountryCommand> logger)
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}