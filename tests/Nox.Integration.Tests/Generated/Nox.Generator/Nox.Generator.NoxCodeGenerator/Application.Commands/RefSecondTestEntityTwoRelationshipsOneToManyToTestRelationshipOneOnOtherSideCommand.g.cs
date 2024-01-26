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

public abstract record RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipOneOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipOneOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsOneToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipOneOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipOneOnOtherSide();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase(
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

	protected async Task<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany?> GetTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsOneToManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
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