
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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToTestEntityOneOrManyToZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, List<TestEntityOneOrManyToZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityOneOrManyToZeroOrMany(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManyToZeroOrManies).LoadAsync();
		entity.UpdateRefToTestEntityOneOrManyToZeroOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToTestEntityOneOrManyToZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManyToZeroOrManies).LoadAsync();
		entity.DeleteAllRefToTestEntityOneOrManyToZeroOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyToOneOrManyEntity?> GetTestEntityZeroOrManyToOneOrMany(TestEntityZeroOrManyToOneOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany?> GetTestEntityOneOrManyToZeroOrMany(TestEntityOneOrManyToZeroOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrManyToOneOrManyEntity entity)
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