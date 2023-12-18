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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request)
    {
		var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOneToOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, List<TestEntityZeroOrOneToOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request)
    {
		var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityZeroOrOneToOneOrMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToOneOrManies).LoadAsync();
		entity.UpdateRefToTestEntityZeroOrOneToOneOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request)
    {
        var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOneToOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request)
    {
        var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToOneOrManies).LoadAsync();
		entity.DeleteAllRefToTestEntityZeroOrOneToOneOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityOneOrManyToZeroOrOneEntity?> GetTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOneKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany?> GetTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityOneOrManyToZeroOrOneEntity entity)
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