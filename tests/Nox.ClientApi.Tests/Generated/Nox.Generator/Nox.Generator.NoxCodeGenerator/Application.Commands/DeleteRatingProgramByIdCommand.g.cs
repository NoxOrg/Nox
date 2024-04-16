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
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Commands;

public partial record DeleteRatingProgramByIdCommand(IEnumerable<RatingProgramKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteRatingProgramByIdCommandHandler : DeleteRatingProgramByIdCommandHandlerBase
{
	public DeleteRatingProgramByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteRatingProgramByIdCommandHandlerBase : CommandCollectionBase<DeleteRatingProgramByIdCommand, RatingProgramEntity>, IRequestHandler<DeleteRatingProgramByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteRatingProgramByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteRatingProgramByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<RatingProgramEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyStoreId = Dto.RatingProgramMetadata.CreateStoreId(keyDto.keyStoreId);
			var keyId = Dto.RatingProgramMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<RatingProgramEntity>(keyStoreId, keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("RatingProgram",  $"{keyStoreId.ToString()}, {keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<RatingProgramEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}