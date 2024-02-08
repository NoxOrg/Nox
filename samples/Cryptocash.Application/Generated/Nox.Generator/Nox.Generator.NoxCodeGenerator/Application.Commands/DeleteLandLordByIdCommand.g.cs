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
using LandLordEntity = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Commands;

public partial record DeleteLandLordByIdCommand(IEnumerable<LandLordKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteLandLordByIdCommandHandler : DeleteLandLordByIdCommandHandlerBase
{
	public DeleteLandLordByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteLandLordByIdCommandHandlerBase : CommandCollectionBase<DeleteLandLordByIdCommand, LandLordEntity>, IRequestHandler<DeleteLandLordByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteLandLordByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteLandLordByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<LandLordEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.LandLordMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<LandLordEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("LandLord",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<LandLordEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}