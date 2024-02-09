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
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityForTypesByIdCommand(IEnumerable<TestEntityForTypesKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityForTypesByIdCommandHandler : DeleteTestEntityForTypesByIdCommandHandlerBase
{
	public DeleteTestEntityForTypesByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForTypesByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityForTypesByIdCommand, TestEntityForTypesEntity>, IRequestHandler<DeleteTestEntityForTypesByIdCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteTestEntityForTypesByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForTypesByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityForTypesEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.TestEntityForTypesMetadata.CreateId(keyDto.keyId);		

			var entity = await Repository.FindAsync<TestEntityForTypesEntity>(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityForTypes",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		Repository.DeleteRange<TestEntityForTypesEntity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}