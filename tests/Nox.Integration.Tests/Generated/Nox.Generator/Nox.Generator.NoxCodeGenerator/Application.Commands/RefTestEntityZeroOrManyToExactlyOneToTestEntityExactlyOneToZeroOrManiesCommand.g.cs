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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, List<TestEntityExactlyOneToZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityExactlyOneToZeroOrMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestEntityExactlyOneToZeroOrManies).LoadAsync();
		entity.UpdateRefToTestEntityExactlyOneToZeroOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestEntityExactlyOneToZeroOrManies).LoadAsync();
		entity.DeleteAllRefToTestEntityExactlyOneToZeroOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyToExactlyOneEntity?> GetTestEntityZeroOrManyToExactlyOne(TestEntityZeroOrManyToExactlyOneKeyDto entityKeyDto)
	{
		var keyId = Dto.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany?> GetTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrManyToExactlyOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}