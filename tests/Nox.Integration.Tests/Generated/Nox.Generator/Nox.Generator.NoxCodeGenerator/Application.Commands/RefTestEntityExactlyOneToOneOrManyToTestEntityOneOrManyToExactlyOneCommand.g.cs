
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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand request)
    {
		var entity = await GetTestEntityExactlyOneToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityOneOrManyToExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOneToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityOneOrManyToExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToTestEntityOneOrManyToExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOneToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		entity.DeleteAllRefToTestEntityOneOrManyToExactlyOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase(
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

	protected async Task<TestEntityExactlyOneToOneOrManyEntity?> GetTestEntityExactlyOneToOneOrMany(TestEntityExactlyOneToOneOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne?> GetTestEntityOneOrManyToExactlyOne(TestEntityOneOrManyToExactlyOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityExactlyOneToOneOrManyEntity entity)
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