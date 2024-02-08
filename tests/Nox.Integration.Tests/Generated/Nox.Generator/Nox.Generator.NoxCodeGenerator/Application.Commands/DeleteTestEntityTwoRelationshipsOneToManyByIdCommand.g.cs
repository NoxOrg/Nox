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
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityTwoRelationshipsOneToManyByIdCommand(IEnumerable<TestEntityTwoRelationshipsOneToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandler : DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase
{
	public DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityTwoRelationshipsOneToManyByIdCommand, TestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<DeleteTestEntityTwoRelationshipsOneToManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityTwoRelationshipsOneToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityTwoRelationshipsOneToManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityTwoRelationshipsOneToManyEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityTwoRelationshipsOneToManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}