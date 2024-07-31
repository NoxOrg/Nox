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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteThirdTestEntityExactlyOneByIdCommand(IEnumerable<ThirdTestEntityExactlyOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteThirdTestEntityExactlyOneByIdCommandHandler : DeleteThirdTestEntityExactlyOneByIdCommandHandlerBase
{
	public DeleteThirdTestEntityExactlyOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityExactlyOneByIdCommandHandlerBase : CommandCollectionBase<DeleteThirdTestEntityExactlyOneByIdCommand, ThirdTestEntityExactlyOneEntity>, IRequestHandler<DeleteThirdTestEntityExactlyOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteThirdTestEntityExactlyOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ThirdTestEntityExactlyOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.ThirdTestEntityExactlyOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<ThirdTestEntityExactlyOneEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("ThirdTestEntityExactlyOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<ThirdTestEntityExactlyOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}