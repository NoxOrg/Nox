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
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand request)
    {
		var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, List<SecondTestEntityTwoRelationshipsOneToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandlerBase<UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand>
{
	public UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand request)
    {
		var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetSecondTestEntityTwoRelationshipsOneToMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOne).LoadAsync();
		entity.UpdateRefToTestRelationshipOne(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand request)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand request)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOne).LoadAsync();
		entity.DeleteAllRefToTestRelationshipOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommandHandlerBase(
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

	protected async Task<TestEntityTwoRelationshipsOneToManyEntity?> GetTestEntityTwoRelationshipsOneToMany(TestEntityTwoRelationshipsOneToManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany?> GetSecondTestEntityTwoRelationshipsOneToMany(SecondTestEntityTwoRelationshipsOneToManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityTwoRelationshipsOneToManyEntity entity)
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