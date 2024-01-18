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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request)
    {
		var entity = await GetTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, List<SecondTestEntityOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request)
    {
		var entity = await GetTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetSecondTestEntityOneOrMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.SecondTestEntityOneOrManies).LoadAsync();
		entity.UpdateRefToSecondTestEntityOneOrManies(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request)
    {
        var entity = await GetTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityOneOrMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityOneOrManies(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request)
    {
        var entity = await GetTestEntityOneOrMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.SecondTestEntityOneOrManies).LoadAsync();
		entity.DeleteAllRefToSecondTestEntityOneOrManies();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityOneOrManyEntity?> GetTestEntityOneOrMany(TestEntityOneOrManyKeyDto entityKeyDto)
	{
		var keyId = Dto.TestEntityOneOrManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityOneOrManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityOneOrMany?> GetSecondTestEntityOneOrMany(SecondTestEntityOneOrManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.SecondTestEntityOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.SecondTestEntityOneOrManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityOneOrManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}