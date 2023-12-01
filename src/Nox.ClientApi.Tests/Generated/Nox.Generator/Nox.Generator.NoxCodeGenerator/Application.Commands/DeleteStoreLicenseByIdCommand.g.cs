// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public partial record DeleteStoreLicenseByIdCommand(IEnumerable<StoreLicenseKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteStoreLicenseByIdCommandHandler : DeleteStoreLicenseByIdCommandHandlerBase
{
	public DeleteStoreLicenseByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteStoreLicenseByIdCommandHandlerBase : CommandBase<DeleteStoreLicenseByIdCommand, StoreLicenseEntity>, IRequestHandler<DeleteStoreLicenseByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteStoreLicenseByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreLicenseByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.StoreLicenses.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new StoreLicenseEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}