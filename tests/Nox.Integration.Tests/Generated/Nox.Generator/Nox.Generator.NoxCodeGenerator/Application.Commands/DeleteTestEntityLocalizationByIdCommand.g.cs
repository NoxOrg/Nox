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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityLocalizationByIdCommand(IEnumerable<TestEntityLocalizationKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityLocalizationByIdCommandHandler : DeleteTestEntityLocalizationByIdCommandHandlerBase
{
	public DeleteTestEntityLocalizationByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityLocalizationByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityLocalizationByIdCommand, TestEntityLocalizationEntity>, IRequestHandler<DeleteTestEntityLocalizationByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityLocalizationByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityLocalizationByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityLocalizationEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityLocalizationMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityLocalizationEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityLocalization",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityLocalizationEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}