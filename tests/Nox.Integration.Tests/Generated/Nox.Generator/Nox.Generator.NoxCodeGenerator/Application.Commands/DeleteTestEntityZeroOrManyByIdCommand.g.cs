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
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityZeroOrManyByIdCommand(IEnumerable<TestEntityZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityZeroOrManyByIdCommandHandler : DeleteTestEntityZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityZeroOrManyByIdCommand, TestEntityZeroOrManyEntity>, IRequestHandler<DeleteTestEntityZeroOrManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityZeroOrManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityZeroOrManyEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityZeroOrManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}