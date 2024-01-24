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

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateCountryQualityOfLifeIndexCommand(System.Int64 keyCountryId, System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryQualityOfLifeIndexKeyDto>;

internal partial class PartialUpdateCountryQualityOfLifeIndexCommandHandler : PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase
{
	public PartialUpdateCountryQualityOfLifeIndexCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase : CommandBase<PartialUpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexEntity>, IRequestHandler<PartialUpdateCountryQualityOfLifeIndexCommand, CountryQualityOfLifeIndexKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCountryQualityOfLifeIndexCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQualityOfLifeIndexKeyDto> Handle(PartialUpdateCountryQualityOfLifeIndexCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyCountryId = Dto.CountryQualityOfLifeIndexMetadata.CreateCountryId(request.keyCountryId);
		var keyId = Dto.CountryQualityOfLifeIndexMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<CountryQualityOfLifeIndex>(keyCountryId, keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryQualityOfLifeIndex",  $"{keyCountryId.ToString()}, {keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CountryQualityOfLifeIndexKeyDto(entity.CountryId.Value, entity.Id.Value);
	}
}