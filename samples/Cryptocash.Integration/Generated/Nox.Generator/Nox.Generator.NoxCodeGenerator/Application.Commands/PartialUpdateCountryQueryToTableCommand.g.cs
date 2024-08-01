// Generated

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
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record PartialUpdateCountryQueryToTableCommand(System.Int32 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryQueryToTableKeyDto>;

internal partial class PartialUpdateCountryQueryToTableCommandHandler : PartialUpdateCountryQueryToTableCommandHandlerBase
{
	public PartialUpdateCountryQueryToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryQueryToTableCommandHandlerBase : CommandBase<PartialUpdateCountryQueryToTableCommand, CountryQueryToTableEntity>, IRequestHandler<PartialUpdateCountryQueryToTableCommand, CountryQueryToTableKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCountryQueryToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToTableKeyDto> Handle(PartialUpdateCountryQueryToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CountryQueryToTableMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<CryptocashIntegration.Domain.CountryQueryToTable>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQueryToTable",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CountryQueryToTableKeyDto(entity.Id.Value);
	}
}