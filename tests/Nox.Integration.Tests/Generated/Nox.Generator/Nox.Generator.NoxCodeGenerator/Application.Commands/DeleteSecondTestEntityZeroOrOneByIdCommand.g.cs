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
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteSecondTestEntityZeroOrOneByIdCommand(IEnumerable<SecondTestEntityZeroOrOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteSecondTestEntityZeroOrOneByIdCommandHandler : DeleteSecondTestEntityZeroOrOneByIdCommandHandlerBase
{
	public DeleteSecondTestEntityZeroOrOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteSecondTestEntityZeroOrOneByIdCommandHandlerBase : CommandBase<DeleteSecondTestEntityZeroOrOneByIdCommand, SecondTestEntityZeroOrOneEntity>, IRequestHandler<DeleteSecondTestEntityZeroOrOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityZeroOrOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityZeroOrOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new SecondTestEntityZeroOrOneEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}