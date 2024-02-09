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
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityForUniqueConstraintsByIdCommand(IEnumerable<TestEntityForUniqueConstraintsKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityForUniqueConstraintsByIdCommandHandler : DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase
{
	public DeleteTestEntityForUniqueConstraintsByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityForUniqueConstraintsByIdCommand, TestEntityForUniqueConstraintsEntity>, IRequestHandler<DeleteTestEntityForUniqueConstraintsByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityForUniqueConstraintsByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForUniqueConstraintsByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityForUniqueConstraintsEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityForUniqueConstraintsMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityForUniqueConstraintsEntity>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("TestEntityForUniqueConstraints",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityForUniqueConstraintsEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}