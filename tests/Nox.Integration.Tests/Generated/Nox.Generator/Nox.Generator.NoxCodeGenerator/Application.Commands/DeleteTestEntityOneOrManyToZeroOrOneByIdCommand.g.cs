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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOneOrManyToZeroOrOneByIdCommand(IEnumerable<TestEntityOneOrManyToZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandler : DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOneOrManyToZeroOrOneByIdCommand, TestEntityOneOrManyToZeroOrOneEntity>, IRequestHandler<DeleteTestEntityOneOrManyToZeroOrOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityOneOrManyToZeroOrOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOneOrManyToZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOneOrManyToZeroOrOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityOneOrManyToZeroOrOneEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityOneOrManyToZeroOrOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}