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
using TestEntityForAutoNumberUsagesEntity = TestWebApp.Domain.TestEntityForAutoNumberUsages;

namespace TestWebApp.Application.Commands;

public partial record DeleteTestEntityForAutoNumberUsagesByIdCommand(IEnumerable<TestEntityForAutoNumberUsagesKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteTestEntityForAutoNumberUsagesByIdCommandHandler : DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase
{
	public DeleteTestEntityForAutoNumberUsagesByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase : CommandCollectionBase<DeleteTestEntityForAutoNumberUsagesByIdCommand, TestEntityForAutoNumberUsagesEntity>, IRequestHandler<DeleteTestEntityForAutoNumberUsagesByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTestEntityForAutoNumberUsagesByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTestEntityForAutoNumberUsagesByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<TestEntityForAutoNumberUsagesEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = TestWebApp.Domain.TestEntityForAutoNumberUsagesMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.TestEntityForAutoNumberUsages.FindAsync(keyId);
			if (entity == null)
			{
				throw new EntityNotFoundException("TestEntityForAutoNumberUsages",  $"{keyId.ToString()}");
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