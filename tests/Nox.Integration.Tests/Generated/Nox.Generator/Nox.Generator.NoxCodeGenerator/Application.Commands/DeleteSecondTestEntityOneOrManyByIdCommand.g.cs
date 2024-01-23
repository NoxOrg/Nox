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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityOneOrManyByIdCommand(IEnumerable<SecondTestEntityOneOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteSecondTestEntityOneOrManyByIdCommandHandler : DeleteSecondTestEntityOneOrManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityOneOrManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityOneOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteSecondTestEntityOneOrManyByIdCommand, SecondTestEntityOneOrManyEntity>, IRequestHandler<DeleteSecondTestEntityOneOrManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteSecondTestEntityOneOrManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityOneOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<SecondTestEntityOneOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.SecondTestEntityOneOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<SecondTestEntityOneOrMany>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<SecondTestEntityOneOrManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}