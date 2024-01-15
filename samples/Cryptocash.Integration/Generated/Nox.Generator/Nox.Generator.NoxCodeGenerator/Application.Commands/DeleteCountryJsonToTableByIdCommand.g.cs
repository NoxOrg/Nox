// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using CryptocashIntegration.Infrastructure.Persistence;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryJsonToTableEntity = CryptocashIntegration.Domain.CountryJsonToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record DeleteCountryJsonToTableByIdCommand(IEnumerable<CountryJsonToTableKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryJsonToTableByIdCommandHandler : DeleteCountryJsonToTableByIdCommandHandlerBase
{
	public DeleteCountryJsonToTableByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountryJsonToTableByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryJsonToTableByIdCommand, CountryJsonToTableEntity>, IRequestHandler<DeleteCountryJsonToTableByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountryJsonToTableByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryJsonToTableByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryJsonToTableEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CountryJsonToTableMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.CountryJsonToTables.FindAsync(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("CountryJsonToTable",  $"{keyId.ToString()}");
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