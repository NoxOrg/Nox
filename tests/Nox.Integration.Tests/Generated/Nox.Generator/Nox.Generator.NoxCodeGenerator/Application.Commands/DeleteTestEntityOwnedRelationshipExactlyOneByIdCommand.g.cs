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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand(IEnumerable<TestEntityOwnedRelationshipExactlyOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandler : DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand, TestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler<DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityOwnedRelationshipExactlyOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOwnedRelationshipExactlyOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityOwnedRelationshipExactlyOne>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityOwnedRelationshipExactlyOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}