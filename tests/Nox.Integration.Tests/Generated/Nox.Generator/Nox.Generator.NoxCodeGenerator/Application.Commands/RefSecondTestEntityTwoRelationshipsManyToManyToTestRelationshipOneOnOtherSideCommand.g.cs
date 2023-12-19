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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand request)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityTwoRelationshipsManyToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, List<TestEntityTwoRelationshipsManyToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand>
{
	public UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand request)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityTwoRelationshipsManyToMany(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOneOnOtherSide).LoadAsync();
		entity.UpdateRefToTestRelationshipOneOnOtherSide(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand request)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityTwoRelationshipsManyToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipOneOnOtherSide(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand request)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.TestRelationshipOneOnOtherSide).LoadAsync();
		entity.DeleteAllRefToTestRelationshipOneOnOtherSide();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand
{
	public AppDbContext DbContext { get; }

	public RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase(
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

	protected async Task<SecondTestEntityTwoRelationshipsManyToManyEntity?> GetSecondTestEntityTwoRelationshipsManyToMany(SecondTestEntityTwoRelationshipsManyToManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany?> GetTestEntityTwoRelationshipsManyToMany(TestEntityTwoRelationshipsManyToManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, SecondTestEntityTwoRelationshipsManyToManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}