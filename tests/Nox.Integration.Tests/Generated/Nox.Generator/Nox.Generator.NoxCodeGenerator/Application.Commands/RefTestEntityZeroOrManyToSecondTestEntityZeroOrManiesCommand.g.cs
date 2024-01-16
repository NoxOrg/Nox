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
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, List<SecondTestEntityZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request)
    {
		var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetSecondTestEntityZeroOrMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.SecondTestEntityZeroOrManies).LoadAsync();
		entity.UpdateRefToSecondTestEntityZeroOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityZeroOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request)
    {
        var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.SecondTestEntityZeroOrManies).LoadAsync();
		entity.DeleteAllRefToSecondTestEntityZeroOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyEntity?> GetTestEntityZeroOrMany(TestEntityZeroOrManyKeyDto entityKeyDto)
	{
		var keyId = Dto.TestEntityZeroOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityZeroOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityZeroOrMany?> GetSecondTestEntityZeroOrMany(SecondTestEntityZeroOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.SecondTestEntityZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.SecondTestEntityZeroOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityZeroOrManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}