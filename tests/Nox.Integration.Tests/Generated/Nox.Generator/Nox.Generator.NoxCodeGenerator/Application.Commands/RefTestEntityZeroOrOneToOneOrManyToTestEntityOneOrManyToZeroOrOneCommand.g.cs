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
using Nox.Exceptions;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand request)
    {
		var entity = await GetTestEntityZeroOrOneToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOneToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOneToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityOneOrManyToZeroOrOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrOneToOneOrManyEntity?> GetTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne?> GetTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrOneToOneOrManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}