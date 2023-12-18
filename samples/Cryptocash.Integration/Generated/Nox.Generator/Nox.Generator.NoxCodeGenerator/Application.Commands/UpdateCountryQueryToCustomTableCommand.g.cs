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
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record UpdateCountryQueryToCustomTableCommand(System.Int32 keyId, CountryQueryToCustomTableUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryQueryToCustomTableKeyDto>;

internal partial class UpdateCountryQueryToCustomTableCommandHandler : UpdateCountryQueryToCustomTableCommandHandlerBase
{
	public UpdateCountryQueryToCustomTableCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryQueryToCustomTableCommandHandlerBase : CommandBase<UpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableEntity>, IRequestHandler<UpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> _entityFactory;
	protected UpdateCountryQueryToCustomTableCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToCustomTableKeyDto> Handle(UpdateCountryQueryToCustomTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateId(request.keyId);

		var entity = await DbContext.CountryQueryToCustomTables.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQueryToCustomTable",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new CountryQueryToCustomTableKeyDto(entity.Id.Value);
	}
}