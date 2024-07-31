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
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommand(IEnumerable<TestEntityOwnedRelationshipZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommandHandler : DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommand, TestEntityOwnedRelationshipZeroOrOneEntity>, IRequestHandler<DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOwnedRelationshipZeroOrOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityOwnedRelationshipZeroOrOneEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityOwnedRelationshipZeroOrOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}