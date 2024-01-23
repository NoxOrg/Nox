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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand request)
    {
		var entity = await GetTestEntityExactlyOneToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOneToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand request)
    {
        var entity = await GetTestEntityExactlyOneToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrOneToExactlyOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
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

	protected async Task<TestEntityExactlyOneToZeroOrOneEntity?> GetTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOneKeyDto entityKeyDto)
	{
		var keyId = Dto.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne?> GetTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityExactlyOneToZeroOrOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}