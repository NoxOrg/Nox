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
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record UpdateCountryQueryToTableCommand(System.Int32 keyId, CountryQueryToTableUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryQueryToTableKeyDto>;

internal partial class UpdateCountryQueryToTableCommandHandler : UpdateCountryQueryToTableCommandHandlerBase
{
	public UpdateCountryQueryToTableCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}

internal abstract class UpdateCountryQueryToTableCommandHandlerBase : CommandBase<UpdateCountryQueryToTableCommand, CountryQueryToTableEntity>, IRequestHandler<UpdateCountryQueryToTableCommand, CountryQueryToTableKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> _entityFactory;

	protected UpdateCountryQueryToTableCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToTableKeyDto> Handle(UpdateCountryQueryToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreateId(request.keyId);

		var entity = await DbContext.CountryQueryToTables.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQueryToTable",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new CountryQueryToTableKeyDto(entity.Id.Value);
	}
}