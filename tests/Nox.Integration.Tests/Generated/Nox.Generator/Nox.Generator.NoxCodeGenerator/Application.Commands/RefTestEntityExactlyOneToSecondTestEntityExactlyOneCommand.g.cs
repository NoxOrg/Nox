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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto, SecondTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand request)
    {
		var entity = await GetTestEntityExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto, SecondTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSecondTestEntityExactlyOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase(
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

	protected async Task<TestEntityExactlyOneEntity?> GetTestEntityExactlyOne(TestEntityExactlyOneKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityExactlyOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityExactlyOne?> GetSecondTestEntityExactlyOne(SecondTestEntityExactlyOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.SecondTestEntityExactlyOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityExactlyOneEntity entity)
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