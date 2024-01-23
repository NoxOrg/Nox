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
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand request)
    {
		var entity = await GetSecondTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand request)
    {
        var entity = await GetSecondTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand request)
    {
        var entity = await GetSecondTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase(
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

	protected async Task<SecondTestEntityZeroOrOneEntity?> GetSecondTestEntityZeroOrOne(SecondTestEntityZeroOrOneKeyDto entityKeyDto)
	{
		var keyId = Dto.SecondTestEntityZeroOrOneMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.SecondTestEntityZeroOrOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOne?> GetTestEntityZeroOrOneRelationship(TestEntityZeroOrOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TestEntityZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, SecondTestEntityZeroOrOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}