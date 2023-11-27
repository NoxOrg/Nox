
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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request)
    {
		var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToTestEntityZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, List<TestEntityZeroOrManyKeyDto> RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request)
    {
		var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityZeroOrMany>();
		foreach(var keyDto in request.RelatedEntityKeyDto)
		{
			var relatedEntity = await GetTestEntityZeroOrMany(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManies).LoadAsync();
		entity.UpdateRefToTestEntityZeroOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request)
    {
        var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToTestEntityZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request)
    {
        var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManies).LoadAsync();
		entity.DeleteAllRefToTestEntityZeroOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase(
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

	protected async Task<SecondTestEntityZeroOrManyEntity?> GetSecondTestEntityZeroOrMany(SecondTestEntityZeroOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrMany?> GetTestEntityZeroOrMany(TestEntityZeroOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, SecondTestEntityZeroOrManyEntity entity)
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