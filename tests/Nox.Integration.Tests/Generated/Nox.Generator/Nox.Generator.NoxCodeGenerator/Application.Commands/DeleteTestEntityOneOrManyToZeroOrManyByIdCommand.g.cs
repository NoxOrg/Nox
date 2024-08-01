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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityOneOrManyToZeroOrManyByIdCommand(IEnumerable<TestEntityOneOrManyToZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandler : DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityOneOrManyToZeroOrManyByIdCommand, TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler<DeleteTestEntityOneOrManyToZeroOrManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityOneOrManyToZeroOrManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityOneOrManyToZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityOneOrManyToZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityOneOrManyToZeroOrManyEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityOneOrManyToZeroOrManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}