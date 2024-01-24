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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand request)
    {
		var entity = await GetTestEntityZeroOrOneToZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrManyToZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOneToZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrManyToZeroOrOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand request)
    {
        var entity = await GetTestEntityZeroOrOneToZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrManyToZeroOrOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneToZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrOneToZeroOrManyEntity?> GetTestEntityZeroOrOneToZeroOrMany(TestEntityZeroOrOneToZeroOrManyKeyDto entityKeyDto)
	{
		var keyId = Dto.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne?> GetTestEntityZeroOrManyToZeroOrOne(TestEntityZeroOrManyToZeroOrOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrOneToZeroOrManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}