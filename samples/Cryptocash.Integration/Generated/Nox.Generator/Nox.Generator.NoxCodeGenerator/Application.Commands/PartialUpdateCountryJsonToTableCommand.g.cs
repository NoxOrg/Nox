﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryJsonToTableEntity = CryptocashIntegration.Domain.CountryJsonToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record PartialUpdateCountryJsonToTableCommand(System.Int32 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryJsonToTableKeyDto>;

internal partial class PartialUpdateCountryJsonToTableCommandHandler : PartialUpdateCountryJsonToTableCommandHandlerBase
{
	public PartialUpdateCountryJsonToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryJsonToTableCommandHandlerBase : CommandBase<PartialUpdateCountryJsonToTableCommand, CountryJsonToTableEntity>, IRequestHandler<PartialUpdateCountryJsonToTableCommand, CountryJsonToTableKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCountryJsonToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryJsonToTableKeyDto> Handle(PartialUpdateCountryJsonToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CountryJsonToTableMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<CryptocashIntegration.Domain.CountryJsonToTable>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryJsonToTable",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CountryJsonToTableKeyDto(entity.Id.Value);
	}
}