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
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwo(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwo(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, List<SecondTestEntityTwoRelationshipsOneToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestRelationshipTwo(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestRelationshipTwo(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwo(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwo(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsOneToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipTwo();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand
{
	public IRepository Repository { get; }

	public RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase(
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

	protected async Task<TestEntityTwoRelationshipsOneToManyEntity?> GetTestEntityTwoRelationshipsOneToMany(TestEntityTwoRelationshipsOneToManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestEntityTwoRelationshipsOneToMany>(keys.ToArray(), x => x.TestRelationshipTwo, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany?> GetTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<SecondTestEntityTwoRelationshipsOneToMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityTwoRelationshipsOneToManyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}