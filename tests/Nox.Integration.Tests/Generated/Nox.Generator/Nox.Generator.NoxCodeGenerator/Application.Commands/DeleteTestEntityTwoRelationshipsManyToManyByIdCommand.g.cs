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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(IEnumerable<TestEntityTwoRelationshipsManyToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandler : DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase
{
	public DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityTwoRelationshipsManyToManyByIdCommand, TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<DeleteTestEntityTwoRelationshipsManyToManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityTwoRelationshipsManyToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityTwoRelationshipsManyToManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityTwoRelationshipsManyToMany>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityTwoRelationshipsManyToManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}