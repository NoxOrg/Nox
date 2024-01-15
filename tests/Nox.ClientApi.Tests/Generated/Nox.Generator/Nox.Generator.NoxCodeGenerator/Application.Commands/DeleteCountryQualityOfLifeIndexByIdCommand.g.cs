// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Commands;

public partial record DeleteCountryQualityOfLifeIndexByIdCommand(IEnumerable<CountryQualityOfLifeIndexKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryQualityOfLifeIndexByIdCommandHandler : DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase
{
	public DeleteCountryQualityOfLifeIndexByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryQualityOfLifeIndexByIdCommand, CountryQualityOfLifeIndexEntity>, IRequestHandler<DeleteCountryQualityOfLifeIndexByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountryQualityOfLifeIndexByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
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

			var entity = await DbContext.CountryQualityOfLifeIndices.FindAsync(keyCountryId, keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("CountryQualityOfLifeIndex",  $"{keyCountryId.ToString()}, {keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}