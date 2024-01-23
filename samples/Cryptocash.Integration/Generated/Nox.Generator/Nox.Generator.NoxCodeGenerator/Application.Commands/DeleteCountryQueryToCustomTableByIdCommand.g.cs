// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record DeleteCountryQueryToCustomTableByIdCommand(IEnumerable<CountryQueryToCustomTableKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryQueryToCustomTableByIdCommandHandler : DeleteCountryQueryToCustomTableByIdCommandHandlerBase
{
	public DeleteCountryQueryToCustomTableByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCountryQueryToCustomTableByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryQueryToCustomTableByIdCommand, CountryQueryToCustomTableEntity>, IRequestHandler<DeleteCountryQueryToCustomTableByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCountryQueryToCustomTableByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCountryQueryToCustomTableByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryQueryToCustomTableEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CountryQueryToCustomTableMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<CountryQueryToCustomTable>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("CountryQueryToCustomTable",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CountryQueryToCustomTableEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}