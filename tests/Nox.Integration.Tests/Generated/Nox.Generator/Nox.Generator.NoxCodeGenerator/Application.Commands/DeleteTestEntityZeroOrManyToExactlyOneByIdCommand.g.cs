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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityZeroOrManyToExactlyOneByIdCommand(IEnumerable<TestEntityZeroOrManyToExactlyOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityZeroOrManyToExactlyOneByIdCommandHandler : DeleteTestEntityZeroOrManyToExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrManyToExactlyOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrManyToExactlyOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityZeroOrManyToExactlyOneByIdCommand, TestEntityZeroOrManyToExactlyOneEntity>, IRequestHandler<DeleteTestEntityZeroOrManyToExactlyOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityZeroOrManyToExactlyOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrManyToExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityZeroOrManyToExactlyOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityZeroOrManyToExactlyOne>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityZeroOrManyToExactlyOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}