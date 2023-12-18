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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand request)
    {
		var entity = await GetTestEntityZeroOrOneToExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOneToExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOneToExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityExactlyOneToZeroOrOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrOneToExactlyOneEntity?> GetTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOneKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne?> GetTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrOneToExactlyOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}
		return true;
	}
}