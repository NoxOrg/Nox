// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using CryptocashIntegration.Infrastructure.Persistence;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record PartialUpdateCountryQueryToCustomTableCommand(System.Int32 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryQueryToCustomTableKeyDto>;

internal partial class PartialUpdateCountryQueryToCustomTableCommandHandler : PartialUpdateCountryQueryToCustomTableCommandHandlerBase
{
	public PartialUpdateCountryQueryToCustomTableCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryQueryToCustomTableCommandHandlerBase : CommandBase<PartialUpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableEntity>, IRequestHandler<PartialUpdateCountryQueryToCustomTableCommand, CountryQueryToCustomTableKeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCountryQueryToCustomTableCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToCustomTableKeyDto> Handle(PartialUpdateCountryQueryToCustomTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateId(request.keyId);

		var entity = await DbContext.CountryQueryToCustomTables.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQueryToCustomTable",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CountryQueryToCustomTableKeyDto(entity.Id.Value);
	}
}