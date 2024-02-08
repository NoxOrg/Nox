// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public partial record DeleteCountryQualityOfLifeIndexByIdCommand(IEnumerable<CountryQualityOfLifeIndexKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryQualityOfLifeIndexByIdCommandHandler : DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase
{
	public DeleteCountryQualityOfLifeIndexByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryQualityOfLifeIndexByIdCommand, CountryQualityOfLifeIndexEntity>, IRequestHandler<DeleteCountryQualityOfLifeIndexByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCountryQualityOfLifeIndexByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryQualityOfLifeIndexEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyCountryId = Dto.CountryQualityOfLifeIndexMetadata.CreateCountryId(keyDto.keyCountryId);
			var keyId = Dto.CountryQualityOfLifeIndexMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<CountryQualityOfLifeIndexEntity>(keyCountryId, keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("CountryQualityOfLifeIndex",  $"{keyCountryId.ToString()}, {keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CountryQualityOfLifeIndexEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}