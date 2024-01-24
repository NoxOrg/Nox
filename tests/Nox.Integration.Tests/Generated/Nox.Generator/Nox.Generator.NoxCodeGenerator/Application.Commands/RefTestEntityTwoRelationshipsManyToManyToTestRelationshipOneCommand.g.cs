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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand>
{
	public CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand request)
    {
		var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, List<SecondTestEntityTwoRelationshipsManyToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand>
{
	public UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand request)
    {
		var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestRelationshipOne(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{keyDto.keyId.ToString()}");
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

public record DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand>
{
	public DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand request)
    {
        var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipOne(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand request)
    {
        var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOne).LoadAsync();
		entity.DeleteAllRefToTestRelationshipOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand
{
	public AppDbContext DbContext { get; }

	public RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase(
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
		var keyId = Dto.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(entityKeyDto.keyId);
		var entity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if(entity is not null)
		{
			await DbContext.Entry(entity).Collection(x => x.TestRelationshipOne).LoadAsync();
		}

		return entity;
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany?> GetTestRelationshipOne(SecondTestEntityTwoRelationshipsManyToManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityKeyDto.keyId);
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