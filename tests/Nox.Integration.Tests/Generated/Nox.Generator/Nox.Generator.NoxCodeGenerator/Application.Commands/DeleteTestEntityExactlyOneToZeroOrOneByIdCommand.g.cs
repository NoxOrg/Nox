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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityExactlyOneToZeroOrOneByIdCommand(IEnumerable<TestEntityExactlyOneToZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandler : DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase
{
	public DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityExactlyOneToZeroOrOneByIdCommand, TestEntityExactlyOneToZeroOrOneEntity>, IRequestHandler<DeleteTestEntityExactlyOneToZeroOrOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityExactlyOneToZeroOrOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityExactlyOneToZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityExactlyOneToZeroOrOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityExactlyOneToZeroOrOneEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityExactlyOneToZeroOrOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}