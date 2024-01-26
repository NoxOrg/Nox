// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipTwoOnOtherSide();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsOneToOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<SecondTestEntityTwoRelationshipsOneToOneEntity?> GetSecondTestEntityTwoRelationshipsOneToOne(SecondTestEntityTwoRelationshipsOneToOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne?> GetTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityTwoRelationshipsOneToOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, SecondTestEntityTwoRelationshipsOneToOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}