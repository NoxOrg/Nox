// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Commands;

public partial record DeleteForReferenceNumberByIdCommand(IEnumerable<ForReferenceNumberKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteForReferenceNumberByIdCommandHandler : DeleteForReferenceNumberByIdCommandHandlerBase
{
	public DeleteForReferenceNumberByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteForReferenceNumberByIdCommandHandlerBase : CommandBase<DeleteForReferenceNumberByIdCommand, ForReferenceNumberEntity>, IRequestHandler<DeleteForReferenceNumberByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteForReferenceNumberByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteForReferenceNumberByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.ForReferenceNumberMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.ForReferenceNumbers.FindAsync(keyId);
			if (entity == null)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;DbContext.ForReferenceNumbers.Remove(entity);
		}

		await OnCompletedAsync(request, new ForReferenceNumberEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}