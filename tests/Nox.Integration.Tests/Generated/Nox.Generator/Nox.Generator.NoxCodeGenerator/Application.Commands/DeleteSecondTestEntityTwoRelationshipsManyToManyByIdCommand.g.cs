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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(IEnumerable<SecondTestEntityTwoRelationshipsManyToManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler : DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase : CommandCollectionBase<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler<DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<SecondTestEntityTwoRelationshipsManyToManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<SecondTestEntityTwoRelationshipsManyToMany>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<SecondTestEntityTwoRelationshipsManyToManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}