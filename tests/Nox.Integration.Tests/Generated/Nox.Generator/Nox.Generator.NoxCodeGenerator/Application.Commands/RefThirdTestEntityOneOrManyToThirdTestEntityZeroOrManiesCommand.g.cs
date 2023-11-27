
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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request)
    {
		var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetThirdTestEntityZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToThirdTestEntityZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, List<ThirdTestEntityZeroOrManyKeyDto> RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request)
    {
		var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<TestWebApp.Domain.ThirdTestEntityZeroOrMany>();
		foreach(var keyDto in request.RelatedEntityKeyDto)
		{
			var relatedEntity = await GetThirdTestEntityZeroOrMany(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityZeroOrManies).LoadAsync();
		entity.UpdateRefToThirdTestEntityZeroOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request)
    {
        var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetThirdTestEntityZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToThirdTestEntityZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request)
    {
        var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityZeroOrManies).LoadAsync();
		entity.DeleteAllRefToThirdTestEntityZeroOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase(
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

	protected async Task<ThirdTestEntityOneOrManyEntity?> GetThirdTestEntityOneOrMany(ThirdTestEntityOneOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.ThirdTestEntityOneOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.ThirdTestEntityZeroOrMany?> GetThirdTestEntityZeroOrMany(ThirdTestEntityZeroOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.ThirdTestEntityZeroOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, ThirdTestEntityOneOrManyEntity entity)
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