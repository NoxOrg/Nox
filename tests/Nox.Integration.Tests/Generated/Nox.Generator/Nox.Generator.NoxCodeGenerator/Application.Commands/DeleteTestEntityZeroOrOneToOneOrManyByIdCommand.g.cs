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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityZeroOrOneToOneOrManyByIdCommand(IEnumerable<TestEntityZeroOrOneToOneOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandler : DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityZeroOrOneToOneOrManyByIdCommand, TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler<DeleteTestEntityZeroOrOneToOneOrManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityZeroOrOneToOneOrManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrOneToOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityZeroOrOneToOneOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityZeroOrOneToOneOrManyEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityZeroOrOneToOneOrManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}