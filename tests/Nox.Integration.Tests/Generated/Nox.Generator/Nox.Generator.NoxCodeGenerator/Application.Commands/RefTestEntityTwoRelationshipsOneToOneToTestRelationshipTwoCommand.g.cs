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

public abstract record RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwo(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwo(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwo(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwo(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipTwo();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand
{
	public IRepository Repository { get; }

	public RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase(
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
		return await Repository.FindAsync<TestEntityTwoRelationshipsOneToOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne?> GetTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityTwoRelationshipsOneToOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}