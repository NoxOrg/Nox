// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand(IEnumerable<SecondTestEntityTwoRelationshipsOneToOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase : CommandCollectionBase<DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand, SecondTestEntityTwoRelationshipsOneToOneEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<SecondTestEntityTwoRelationshipsOneToOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToOne>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<SecondTestEntityTwoRelationshipsOneToOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}