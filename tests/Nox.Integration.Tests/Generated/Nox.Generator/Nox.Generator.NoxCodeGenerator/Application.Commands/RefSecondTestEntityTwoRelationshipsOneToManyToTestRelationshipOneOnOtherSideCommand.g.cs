
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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand request)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityTwoRelationshipsOneToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand request)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTestEntityTwoRelationshipsOneToMany(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToTestRelationshipOneOnOtherSide(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand request)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		entity.DeleteAllRefToTestRelationshipOneOnOtherSide();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand
{
	public AppDbContext DbContext { get; }

	public RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase(
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

	protected async Task<SecondTestEntityTwoRelationshipsOneToManyEntity?> GetSecondTestEntityTwoRelationshipsOneToMany(SecondTestEntityTwoRelationshipsOneToManyKeyDto entityKeyDto)
	{
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany?> GetTestEntityTwoRelationshipsOneToMany(TestEntityTwoRelationshipsOneToManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, SecondTestEntityTwoRelationshipsOneToManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}