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
using CountryProcToTableEntity = CryptocashIntegration.Domain.CountryProcToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record DeleteCountryProcToTableByIdCommand(IEnumerable<CountryProcToTableKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryProcToTableByIdCommandHandler : DeleteCountryProcToTableByIdCommandHandlerBase
{
	public DeleteCountryProcToTableByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCountryProcToTableByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryProcToTableByIdCommand, CountryProcToTableEntity>, IRequestHandler<DeleteCountryProcToTableByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCountryProcToTableByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCountryProcToTableByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryProcToTableEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyCountryId = Dto.CountryProcToTableMetadata.CreateCountryId(keyDto.keyCountryId);		

			var entity = await Repository.FindAsync<CountryProcToTableEntity>(keyCountryId);
			if (entity == null)
			{
				throw new EntityNotFoundException("CountryProcToTable",  $"{keyCountryId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CountryProcToTableEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}