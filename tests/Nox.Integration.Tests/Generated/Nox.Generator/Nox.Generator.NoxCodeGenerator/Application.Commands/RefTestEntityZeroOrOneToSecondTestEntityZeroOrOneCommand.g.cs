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
using Dto = TestWebApp.Application.Dto;
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand request)
    {
		var entity = await GetTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSecondTestEntityZeroOrOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrOneEntity?> GetTestEntityZeroOrOne(TestEntityZeroOrOneKeyDto entityKeyDto)
	{
		var keyId = Dto.TestEntityZeroOrOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityZeroOrOne?> GetSecondTestEntityZeroOrOne(SecondTestEntityZeroOrOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.SecondTestEntityZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.SecondTestEntityZeroOrOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}