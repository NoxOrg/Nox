﻿
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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request)
    {
		var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetThirdTestEntityOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToThirdTestEntityOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, List<ThirdTestEntityOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request)
    {
		var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<TestWebApp.Domain.ThirdTestEntityOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetThirdTestEntityOneOrMany(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityOneOrManies).LoadAsync();
		entity.UpdateRefToThirdTestEntityOneOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request)
    {
        var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetThirdTestEntityOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToThirdTestEntityOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request)
    {
        var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityOneOrManies).LoadAsync();
		entity.DeleteAllRefToThirdTestEntityOneOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase(
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

	protected async Task<ThirdTestEntityZeroOrManyEntity?> GetThirdTestEntityZeroOrMany(ThirdTestEntityZeroOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.ThirdTestEntityZeroOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.ThirdTestEntityOneOrMany?> GetThirdTestEntityOneOrMany(ThirdTestEntityOneOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.ThirdTestEntityOneOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, ThirdTestEntityZeroOrManyEntity entity)
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