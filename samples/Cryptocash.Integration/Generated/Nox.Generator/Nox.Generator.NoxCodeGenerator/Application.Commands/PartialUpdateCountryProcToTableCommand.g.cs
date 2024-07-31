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
using CountryProcToTableEntity = CryptocashIntegration.Domain.CountryProcToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record PartialUpdateCountryProcToTableCommand(System.Int32 keyCountryId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryProcToTableKeyDto>;

internal partial class PartialUpdateCountryProcToTableCommandHandler : PartialUpdateCountryProcToTableCommandHandlerBase
{
	public PartialUpdateCountryProcToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryProcToTableCommandHandlerBase : CommandBase<PartialUpdateCountryProcToTableCommand, CountryProcToTableEntity>, IRequestHandler<PartialUpdateCountryProcToTableCommand, CountryProcToTableKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCountryProcToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryProcToTableKeyDto> Handle(PartialUpdateCountryProcToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyCountryId = Dto.CountryProcToTableMetadata.CreateCountryId(request.keyCountryId);

		var entity = await Repository.FindAsync<CryptocashIntegration.Domain.CountryProcToTable>(keyCountryId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryProcToTable",  $"{keyCountryId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CountryProcToTableKeyDto(entity.CountryId.Value);
	}
}