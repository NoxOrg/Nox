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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(IEnumerable<SecondTestEntityTwoRelationshipsOneToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase : CommandCollectionBase<DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<SecondTestEntityTwoRelationshipsOneToManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToManyEntity>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<SecondTestEntityTwoRelationshipsOneToManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}