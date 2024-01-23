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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOneOrManyToExactlyOneByIdCommand(IEnumerable<TestEntityOneOrManyToExactlyOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandler : DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOneOrManyToExactlyOneByIdCommand, TestEntityOneOrManyToExactlyOneEntity>, IRequestHandler<DeleteTestEntityOneOrManyToExactlyOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityOneOrManyToExactlyOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOneOrManyToExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOneOrManyToExactlyOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityOneOrManyToExactlyOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityOneOrManyToExactlyOne>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityOneOrManyToExactlyOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityOneOrManyToExactlyOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}