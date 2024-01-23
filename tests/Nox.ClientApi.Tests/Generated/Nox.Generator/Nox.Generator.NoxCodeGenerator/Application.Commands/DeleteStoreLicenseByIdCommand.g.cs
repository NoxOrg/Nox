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
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public partial record DeleteStoreLicenseByIdCommand(IEnumerable<StoreLicenseKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteStoreLicenseByIdCommandHandler : DeleteStoreLicenseByIdCommandHandlerBase
{
	public DeleteStoreLicenseByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteStoreLicenseByIdCommandHandlerBase : CommandCollectionBase<DeleteStoreLicenseByIdCommand, StoreLicenseEntity>, IRequestHandler<DeleteStoreLicenseByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteStoreLicenseByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteStoreLicenseByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<StoreLicenseEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.StoreLicenseMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<StoreLicense>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("StoreLicense",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<StoreLicenseEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}