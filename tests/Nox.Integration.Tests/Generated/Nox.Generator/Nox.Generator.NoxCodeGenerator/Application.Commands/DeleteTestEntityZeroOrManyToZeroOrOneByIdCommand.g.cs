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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityZeroOrManyToZeroOrOneByIdCommand(IEnumerable<TestEntityZeroOrManyToZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityZeroOrManyToZeroOrOneByIdCommandHandler : DeleteTestEntityZeroOrManyToZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrManyToZeroOrOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrManyToZeroOrOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityZeroOrManyToZeroOrOneByIdCommand, TestEntityZeroOrManyToZeroOrOneEntity>, IRequestHandler<DeleteTestEntityZeroOrManyToZeroOrOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityZeroOrManyToZeroOrOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrManyToZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityZeroOrManyToZeroOrOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityZeroOrManyToZeroOrOne>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityZeroOrManyToZeroOrOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}