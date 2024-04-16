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
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateCountryCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <CountryKeyDto>;

internal partial class PartialUpdateCountryCommandHandler : PartialUpdateCountryCommandHandlerBase
{
	public PartialUpdateCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateCountryCommandHandlerBase : CommandBase<PartialUpdateCountryCommand, CountryEntity>, IRequestHandler<PartialUpdateCountryCommand, CountryKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> EntityFactory { get; }
	
	public PartialUpdateCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryKeyDto> Handle(PartialUpdateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.CountryMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<ClientApi.Domain.Country>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new CountryKeyDto(entity.Id.Value);
	}
}