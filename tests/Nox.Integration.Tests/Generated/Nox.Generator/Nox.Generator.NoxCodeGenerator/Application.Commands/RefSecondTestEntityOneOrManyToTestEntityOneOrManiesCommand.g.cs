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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request)
    {
		var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, List<TestEntityOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request)
    {
		var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityOneOrMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManies).LoadAsync();
		entity.UpdateRefToTestEntityOneOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request)
    {
        var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request)
    {
        var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManies).LoadAsync();
		entity.DeleteAllRefToTestEntityOneOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase(
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

	protected async Task<SecondTestEntityOneOrManyEntity?> GetSecondTestEntityOneOrMany(SecondTestEntityOneOrManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.SecondTestEntityOneOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrMany?> GetTestEntityOneOrMany(TestEntityOneOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityOneOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, SecondTestEntityOneOrManyEntity entity)
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