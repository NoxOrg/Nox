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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityForAutoNumberUsagesByIdCommand(IEnumerable<TestEntityForAutoNumberUsagesKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityForAutoNumberUsagesByIdCommandHandler : DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase
{
	public DeleteTestEntityForAutoNumberUsagesByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityForAutoNumberUsagesByIdCommand, TestEntityForAutoNumberUsagesEntity>, IRequestHandler<DeleteTestEntityForAutoNumberUsagesByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForAutoNumberUsagesByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityForAutoNumberUsagesEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityForAutoNumberUsagesMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityForAutoNumberUsages>(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("TestEntityForAutoNumberUsages",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityForAutoNumberUsagesEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}