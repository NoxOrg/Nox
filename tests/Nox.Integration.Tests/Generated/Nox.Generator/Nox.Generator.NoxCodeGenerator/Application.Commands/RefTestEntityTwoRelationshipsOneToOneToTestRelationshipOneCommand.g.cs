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
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand
{
	public IRepository Repository { get; }

	public RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase(
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

	protected async Task<TestEntityTwoRelationshipsOneToOneEntity?> GetTestEntityTwoRelationshipsOneToOne(TestEntityTwoRelationshipsOneToOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne?> GetTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityTwoRelationshipsOneToOneEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}