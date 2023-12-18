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

public abstract record RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request)
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

		entity.CreateRefToTestRelationshipTwo(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, List<SecondTestEntityTwoRelationshipsOneToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request)
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

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipTwo).LoadAsync();
		entity.UpdateRefToTestRelationshipTwo(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request)
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

		entity.DeleteRefToTestRelationshipTwo(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestRelationshipTwo).LoadAsync();
		entity.DeleteAllRefToTestRelationshipTwo();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase(
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