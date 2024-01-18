// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityZeroOrManyByIdCommand(IEnumerable<SecondTestEntityZeroOrManyKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteSecondTestEntityZeroOrManyByIdCommandHandler : DeleteSecondTestEntityZeroOrManyByIdCommandHandlerBase
{
	public DeleteSecondTestEntityZeroOrManyByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityZeroOrManyByIdCommandHandlerBase : CommandCollectionBase<DeleteSecondTestEntityZeroOrManyByIdCommand, SecondTestEntityZeroOrManyEntity>, IRequestHandler<DeleteSecondTestEntityZeroOrManyByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityZeroOrManyByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityZeroOrManyByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<SecondTestEntityZeroOrManyEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.SecondTestEntityZeroOrManyMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("SecondTestEntityZeroOrMany",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}