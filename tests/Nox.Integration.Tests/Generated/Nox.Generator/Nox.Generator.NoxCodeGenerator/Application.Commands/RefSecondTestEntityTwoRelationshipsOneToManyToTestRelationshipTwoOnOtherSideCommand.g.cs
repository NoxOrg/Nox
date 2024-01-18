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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand request)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand request)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand request)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipTwoOnOtherSide();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand
{
	public AppDbContext DbContext { get; }

	public RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase(
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
		var keyId = Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany?> GetTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToManyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, SecondTestEntityTwoRelationshipsOneToManyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}