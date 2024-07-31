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


using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryProcToTableEntity = CryptocashIntegration.Domain.CountryProcToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record UpdateCountryProcToTableCommand(System.Int32 keyCountryId, CountryProcToTableUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryProcToTableKeyDto>;

internal partial class UpdateCountryProcToTableCommandHandler : UpdateCountryProcToTableCommandHandlerBase
{
	public UpdateCountryProcToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryProcToTableCommandHandlerBase : CommandBase<UpdateCountryProcToTableCommand, CountryProcToTableEntity>, IRequestHandler<UpdateCountryProcToTableCommand, CountryProcToTableKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> EntityFactory { get; }
	protected UpdateCountryProcToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryProcToTableKeyDto> Handle(UpdateCountryProcToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<CryptocashIntegration.Domain.CountryProcToTable>()
            .Where(x => x.CountryId == Dto.CountryProcToTableMetadata.CreateCountryId(request.keyCountryId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryProcToTable",  "keyCountryId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		Repository.Update(entity);
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new CountryProcToTableKeyDto(entity.CountryId.Value);
	}
}