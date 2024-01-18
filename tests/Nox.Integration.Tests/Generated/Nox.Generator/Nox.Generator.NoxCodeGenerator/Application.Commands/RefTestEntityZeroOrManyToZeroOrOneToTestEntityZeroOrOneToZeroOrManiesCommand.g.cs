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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOneToZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, List<TestEntityZeroOrOneToZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityZeroOrOneToZeroOrMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToZeroOrManies).LoadAsync();
		entity.UpdateRefToTestEntityZeroOrOneToZeroOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOneToZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToZeroOrManies).LoadAsync();
		entity.DeleteAllRefToTestEntityZeroOrOneToZeroOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyToZeroOrOneEntity?> GetTestEntityZeroOrManyToZeroOrOne(TestEntityZeroOrManyToZeroOrOneKeyDto entityKeyDto)
	{
		var keyId = Dto.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany?> GetTestEntityZeroOrOneToZeroOrMany(TestEntityZeroOrOneToZeroOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrManyToZeroOrOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}