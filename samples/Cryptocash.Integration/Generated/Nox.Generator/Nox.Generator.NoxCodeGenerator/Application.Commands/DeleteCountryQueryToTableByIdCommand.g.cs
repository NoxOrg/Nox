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
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record DeleteCountryQueryToTableByIdCommand(IEnumerable<CountryQueryToTableKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryQueryToTableByIdCommandHandler : DeleteCountryQueryToTableByIdCommandHandlerBase
{
	public DeleteCountryQueryToTableByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCountryQueryToTableByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryQueryToTableByIdCommand, CountryQueryToTableEntity>, IRequestHandler<DeleteCountryQueryToTableByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCountryQueryToTableByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCountryQueryToTableByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryQueryToTableEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CountryQueryToTableMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<CountryQueryToTableEntity>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("CountryQueryToTable",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CountryQueryToTableEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}