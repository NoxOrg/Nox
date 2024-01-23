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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteThirdTestEntityZeroOrManyByIdCommand(IEnumerable<ThirdTestEntityZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteThirdTestEntityZeroOrManyByIdCommandHandler : DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase
{
	public DeleteThirdTestEntityZeroOrManyByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteThirdTestEntityZeroOrManyByIdCommand, ThirdTestEntityZeroOrManyEntity>, IRequestHandler<DeleteThirdTestEntityZeroOrManyByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteThirdTestEntityZeroOrManyByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ThirdTestEntityZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.ThirdTestEntityZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<ThirdTestEntityZeroOrMany>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("ThirdTestEntityZeroOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<ThirdTestEntityZeroOrManyEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}