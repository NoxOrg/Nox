// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using CryptocashIntegration.Infrastructure.Persistence;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record DeleteCountryQueryToCustomTableByIdCommand(IEnumerable<CountryQueryToCustomTableKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryQueryToCustomTableByIdCommandHandler : DeleteCountryQueryToCustomTableByIdCommandHandlerBase
{
	public DeleteCountryQueryToCustomTableByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCountryQueryToCustomTableByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryQueryToCustomTableByIdCommand, CountryQueryToCustomTableEntity>, IRequestHandler<DeleteCountryQueryToCustomTableByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountryQueryToCustomTableByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryQueryToCustomTableByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryQueryToCustomTableEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.CountryQueryToCustomTables.FindAsync(keyId);
			if (entity == null)
			{
				return false;
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