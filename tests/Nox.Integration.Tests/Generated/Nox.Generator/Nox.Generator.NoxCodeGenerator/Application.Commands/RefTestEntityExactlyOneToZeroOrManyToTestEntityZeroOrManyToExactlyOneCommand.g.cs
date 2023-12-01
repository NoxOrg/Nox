﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand request)
    {
		var entity = await GetTestEntityExactlyOneToZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityZeroOrManyToExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOneToZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityZeroOrManyToExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOneToZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		entity.DeleteAllRefToTestEntityZeroOrManyToExactlyOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<TestEntityExactlyOneToZeroOrManyEntity?> GetTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne?> GetTestEntityZeroOrManyToExactlyOne(TestEntityZeroOrManyToExactlyOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityExactlyOneToZeroOrManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}