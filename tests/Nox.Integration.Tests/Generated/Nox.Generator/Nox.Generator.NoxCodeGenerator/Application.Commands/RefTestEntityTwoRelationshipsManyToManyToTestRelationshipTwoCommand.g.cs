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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request)
    {
		var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwo(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, List<SecondTestEntityTwoRelationshipsManyToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request)
    {
		var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetSecondTestEntityTwoRelationshipsManyToMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{keyDto.keyId.ToString()}");
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

public record DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request)
    {
        var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwo(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request)
    {
        var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestRelationshipTwo).LoadAsync();
		entity.DeleteAllRefToTestRelationshipTwo();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase(
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

	protected async Task<TestEntityTwoRelationshipsManyToManyEntity?> GetTestEntityTwoRelationshipsManyToMany(TestEntityTwoRelationshipsManyToManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany?> GetSecondTestEntityTwoRelationshipsManyToMany(SecondTestEntityTwoRelationshipsManyToManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TestEntityTwoRelationshipsManyToManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}