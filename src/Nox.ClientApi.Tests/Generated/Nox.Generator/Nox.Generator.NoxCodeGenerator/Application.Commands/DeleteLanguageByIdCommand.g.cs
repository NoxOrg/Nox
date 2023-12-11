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
using LanguageEntity = ClientApi.Domain.Language;

namespace ClientApi.Application.Commands;

public partial record DeleteLanguageByIdCommand(IEnumerable<LanguageKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteLanguageByIdCommandHandler : DeleteLanguageByIdCommandHandlerBase
{
	public DeleteLanguageByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteLanguageByIdCommandHandlerBase : CommandCollectionBase<DeleteLanguageByIdCommand, LanguageEntity>, IRequestHandler<DeleteLanguageByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteLanguageByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteLanguageByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<LanguageEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = ClientApi.Domain.LanguageMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.Languages.FindAsync(keyId);
			if (entity == null)
			{
				return false;
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