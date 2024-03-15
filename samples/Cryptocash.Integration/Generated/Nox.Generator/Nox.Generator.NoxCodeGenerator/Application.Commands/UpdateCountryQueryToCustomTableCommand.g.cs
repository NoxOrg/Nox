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
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record UpdateCountryQueryToCustomTableCommand(System.Int32 keyId, CountryQueryToCustomTableUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CountryQueryToCustomTableKeyDto>;

internal partial class UpdateCountryQueryToCustomTableCommandHandler : UpdateCountryQueryToCustomTableCommandHandlerBase
{
	public UpdateCountryQueryToCustomTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCountryQueryToCustomTableCommandHandlerBase : CommandBase<UpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableEntity>, IRequestHandler<UpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> EntityFactory { get; }
	protected UpdateCountryQueryToCustomTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToCustomTableKeyDto> Handle(UpdateCountryQueryToCustomTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<CryptocashIntegration.Domain.CountryQueryToCustomTable>()
            .Where(x => x.Id == Dto.CountryQueryToCustomTableMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQueryToCustomTable",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new CountryQueryToCustomTableKeyDto(entity.Id.Value);
	}
}