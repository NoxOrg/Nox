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
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Commands;

public partial record DeleteForReferenceNumberByIdCommand(IEnumerable<ForReferenceNumberKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteForReferenceNumberByIdCommandHandler : DeleteForReferenceNumberByIdCommandHandlerBase
{
	public DeleteForReferenceNumberByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteForReferenceNumberByIdCommandHandlerBase : CommandCollectionBase<DeleteForReferenceNumberByIdCommand, ForReferenceNumberEntity>, IRequestHandler<DeleteForReferenceNumberByIdCommand, bool>
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
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<ForReferenceNumberEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.ForReferenceNumberMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.ForReferenceNumbers.FindAsync(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("ForReferenceNumber",  $"{keyId.ToString()}");
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