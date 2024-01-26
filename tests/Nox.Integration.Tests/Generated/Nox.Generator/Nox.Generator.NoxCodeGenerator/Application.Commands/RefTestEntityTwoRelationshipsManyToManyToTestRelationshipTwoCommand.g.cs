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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwo(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwo(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, List<SecondTestEntityTwoRelationshipsManyToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestRelationshipTwo(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestRelationshipTwo(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwo(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwo(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipTwo();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand
{
	public IRepository Repository { get; }

	public RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase(
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

	protected async Task<TestEntityTwoRelationshipsManyToManyEntity?> GetTestEntityTwoRelationshipsManyToMany(TestEntityTwoRelationshipsManyToManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestEntityTwoRelationshipsManyToMany>(keys.ToArray(), x => x.TestRelationshipTwo, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany?> GetTestRelationshipTwo(SecondTestEntityTwoRelationshipsManyToManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<SecondTestEntityTwoRelationshipsManyToMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityTwoRelationshipsManyToManyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}