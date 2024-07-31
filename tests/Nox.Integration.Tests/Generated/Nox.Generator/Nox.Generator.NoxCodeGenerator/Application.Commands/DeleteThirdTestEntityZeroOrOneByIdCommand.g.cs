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
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteThirdTestEntityZeroOrOneByIdCommand(IEnumerable<ThirdTestEntityZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteThirdTestEntityZeroOrOneByIdCommandHandler : DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase
{
	public DeleteThirdTestEntityZeroOrOneByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase : CommandCollectionBase<DeleteThirdTestEntityZeroOrOneByIdCommand, ThirdTestEntityZeroOrOneEntity>, IRequestHandler<DeleteThirdTestEntityZeroOrOneByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteThirdTestEntityZeroOrOneByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteThirdTestEntityZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ThirdTestEntityZeroOrOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.ThirdTestEntityZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<ThirdTestEntityZeroOrOneEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<ThirdTestEntityZeroOrOneEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}