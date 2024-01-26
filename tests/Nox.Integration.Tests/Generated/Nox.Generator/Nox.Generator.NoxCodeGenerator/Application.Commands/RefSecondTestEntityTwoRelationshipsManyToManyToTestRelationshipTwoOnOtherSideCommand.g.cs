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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsManyToMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, List<TestEntityTwoRelationshipsManyToManyKeyDto> RelatedEntitiesKeysDtos)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand>
{
	public UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestRelationshipTwoOnOtherSide(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestRelationshipTwoOnOtherSide(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestRelationshipTwoOnOtherSide(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestRelationshipTwoOnOtherSide(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityTwoRelationshipsManyToMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestRelationshipTwoOnOtherSide();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommandHandlerBase(
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

	protected async Task<SecondTestEntityTwoRelationshipsManyToManyEntity?> GetSecondTestEntityTwoRelationshipsManyToMany(SecondTestEntityTwoRelationshipsManyToManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<SecondTestEntityTwoRelationshipsManyToMany>(keys.ToArray(), x => x.TestRelationshipTwoOnOtherSide, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany?> GetTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsManyToManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityTwoRelationshipsManyToMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, SecondTestEntityTwoRelationshipsManyToManyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}