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
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record DeleteCountryQueryToTableByIdCommand(IEnumerable<CountryQueryToTableKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryQueryToTableByIdCommandHandler : DeleteCountryQueryToTableByIdCommandHandlerBase
{
	public DeleteCountryQueryToTableByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountryQueryToTableByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryQueryToTableByIdCommand, CountryQueryToTableEntity>, IRequestHandler<DeleteCountryQueryToTableByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountryQueryToTableByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryQueryToTableByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryQueryToTableEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.CountryQueryToTables.FindAsync(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("CountryQueryToTable",  $"{keyId.ToString()}");
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