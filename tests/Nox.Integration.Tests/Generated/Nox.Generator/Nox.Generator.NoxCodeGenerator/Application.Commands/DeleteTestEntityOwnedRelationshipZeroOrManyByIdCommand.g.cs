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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand(IEnumerable<TestEntityOwnedRelationshipZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandler : DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand, TestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler<DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOwnedRelationshipZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityOwnedRelationshipZeroOrManyEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityOwnedRelationshipZeroOrManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}