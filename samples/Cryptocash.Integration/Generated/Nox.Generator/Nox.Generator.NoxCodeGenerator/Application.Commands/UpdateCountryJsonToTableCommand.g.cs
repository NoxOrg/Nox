﻿﻿
// Generated

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
using CryptocashIntegration.Infrastructure.Persistence;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryJsonToTableEntity = CryptocashIntegration.Domain.CountryJsonToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record UpdateCountryJsonToTableCommand(System.Int32 keyId, CountryJsonToTableUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryJsonToTableKeyDto>;

internal partial class UpdateCountryJsonToTableCommandHandler : UpdateCountryJsonToTableCommandHandlerBase
{
	public UpdateCountryJsonToTableCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryJsonToTableCommandHandlerBase : CommandBase<UpdateCountryJsonToTableCommand, CountryJsonToTableEntity>, IRequestHandler<UpdateCountryJsonToTableCommand, CountryJsonToTableKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> _entityFactory;
	protected UpdateCountryJsonToTableCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryJsonToTableKeyDto> Handle(UpdateCountryJsonToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CountryJsonToTableMetadata.CreateId(request.keyId);

		var entity = await DbContext.CountryJsonToTables.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryJsonToTable",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new CountryJsonToTableKeyDto(entity.Id.Value);
	}
}