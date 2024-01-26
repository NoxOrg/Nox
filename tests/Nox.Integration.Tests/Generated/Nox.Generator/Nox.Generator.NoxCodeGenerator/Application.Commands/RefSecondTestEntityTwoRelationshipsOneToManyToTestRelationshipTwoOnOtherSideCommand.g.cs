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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipTwoOnOtherSide();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase(
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

	protected async Task<SecondTestEntityTwoRelationshipsOneToManyEntity?> GetSecondTestEntityTwoRelationshipsOneToMany(SecondTestEntityTwoRelationshipsOneToManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany?> GetTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityTwoRelationshipsOneToMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, SecondTestEntityTwoRelationshipsOneToManyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}