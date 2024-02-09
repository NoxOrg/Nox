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
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record PartialUpdateCountryQueryToCustomTableCommand(System.Int32 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryQueryToCustomTableKeyDto>;

internal partial class PartialUpdateCountryQueryToCustomTableCommandHandler : PartialUpdateCountryQueryToCustomTableCommandHandlerBase
{
	public PartialUpdateCountryQueryToCustomTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryQueryToCustomTableCommandHandlerBase : CommandBase<PartialUpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableEntity>, IRequestHandler<PartialUpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCountryQueryToCustomTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToCustomTableKeyDto> Handle(PartialUpdateCountryQueryToCustomTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CountryQueryToCustomTableMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<CryptocashIntegration.Domain.CountryQueryToCustomTable>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQueryToCustomTable",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CountryQueryToCustomTableKeyDto(entity.Id.Value);
	}
}