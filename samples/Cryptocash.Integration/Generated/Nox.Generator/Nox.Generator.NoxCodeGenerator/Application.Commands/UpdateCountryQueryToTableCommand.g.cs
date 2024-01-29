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
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record UpdateCountryQueryToTableCommand(System.Int32 keyId, CountryQueryToTableUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryQueryToTableKeyDto>;

internal partial class UpdateCountryQueryToTableCommandHandler : UpdateCountryQueryToTableCommandHandlerBase
{
	public UpdateCountryQueryToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryQueryToTableCommandHandlerBase : CommandBase<UpdateCountryQueryToTableCommand, CountryQueryToTableEntity>, IRequestHandler<UpdateCountryQueryToTableCommand, CountryQueryToTableKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> EntityFactory { get; }
	protected UpdateCountryQueryToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToTableKeyDto> Handle(UpdateCountryQueryToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<CountryQueryToTable>()
            .Where(x => x.Id == Dto.CountryQueryToTableMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQueryToTable",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new CountryQueryToTableKeyDto(entity.Id.Value);
	}
}