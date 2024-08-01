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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand(IEnumerable<TestEntityZeroOrOneToZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandler : DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandlerBase
{
	public DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand, TestEntityZeroOrOneToZeroOrManyEntity>, IRequestHandler<DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityZeroOrOneToZeroOrManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityZeroOrOneToZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityZeroOrOneToZeroOrManyEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityZeroOrOneToZeroOrManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}