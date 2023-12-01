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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityLocalizationByIdCommand(IEnumerable<TestEntityLocalizationKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTestEntityLocalizationByIdCommandHandler : DeleteTestEntityLocalizationByIdCommandHandlerBase
{
	public DeleteTestEntityLocalizationByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityLocalizationByIdCommandHandlerBase : CommandBase<DeleteTestEntityLocalizationByIdCommand, TestEntityLocalizationEntity>, IRequestHandler<DeleteTestEntityLocalizationByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityLocalizationByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityLocalizationByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityLocalizations.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new TestEntityLocalizationEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}