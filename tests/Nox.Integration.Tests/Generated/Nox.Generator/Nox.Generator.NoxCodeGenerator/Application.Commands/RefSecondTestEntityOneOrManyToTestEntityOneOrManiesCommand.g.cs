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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, List<TestEntityOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityOneOrManyRelationship(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityOneOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand>
{
	public DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityOneOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommandHandlerBase(
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

	protected async Task<SecondTestEntityOneOrManyEntity?> GetSecondTestEntityOneOrMany(SecondTestEntityOneOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityOneOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<SecondTestEntityOneOrMany>(keys.ToArray(), x => x.TestEntityOneOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrMany?> GetTestEntityOneOrManyRelationship(TestEntityOneOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, SecondTestEntityOneOrManyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}