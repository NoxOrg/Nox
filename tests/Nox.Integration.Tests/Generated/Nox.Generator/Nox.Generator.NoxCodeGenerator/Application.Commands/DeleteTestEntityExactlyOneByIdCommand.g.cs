﻿// Generated

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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityExactlyOneByIdCommand(IEnumerable<TestEntityExactlyOneKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityExactlyOneByIdCommandHandler : DeleteTestEntityExactlyOneByIdCommandHandlerBase
{
	public DeleteTestEntityExactlyOneByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityExactlyOneByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityExactlyOneByIdCommand, TestEntityExactlyOneEntity>, IRequestHandler<DeleteTestEntityExactlyOneByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityExactlyOneByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityExactlyOneByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityExactlyOneEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityExactlyOnes.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("TestEntityExactlyOne",  $"{keyId.ToString()}");
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