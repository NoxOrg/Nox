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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand request)
    {
		var entity = await GetSecondTestEntityExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand request)
    {
        var entity = await GetSecondTestEntityExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand request)
    {
        var entity = await GetSecondTestEntityExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityExactlyOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase(
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

	protected async Task<SecondTestEntityExactlyOneEntity?> GetSecondTestEntityExactlyOne(SecondTestEntityExactlyOneKeyDto entityKeyDto)
	{
		var keyId = Dto.SecondTestEntityExactlyOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.SecondTestEntityExactlyOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityExactlyOne?> GetTestEntityExactlyOne(TestEntityExactlyOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TestEntityExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityExactlyOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, SecondTestEntityExactlyOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}