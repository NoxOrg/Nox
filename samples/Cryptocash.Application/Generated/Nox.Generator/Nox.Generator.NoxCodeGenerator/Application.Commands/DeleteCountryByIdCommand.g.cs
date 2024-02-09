// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public partial record DeleteCountryByIdCommand(IEnumerable<CountryKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCountryByIdCommandHandler : DeleteCountryByIdCommandHandlerBase
{
	public DeleteCountryByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteCountryByIdCommandHandlerBase : CommandCollectionBase<DeleteCountryByIdCommand, CountryEntity>, IRequestHandler<DeleteCountryByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCountryByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CountryEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CountryMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<CountryEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<CountryEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}