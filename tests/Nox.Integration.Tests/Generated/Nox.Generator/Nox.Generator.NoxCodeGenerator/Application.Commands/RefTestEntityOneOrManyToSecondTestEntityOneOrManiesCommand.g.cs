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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityOneOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, List<SecondTestEntityOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetSecondTestEntityOneOrManyRelationship(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToSecondTestEntityOneOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityOneOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSecondTestEntityOneOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityOneOrManyEntity?> GetTestEntityOneOrMany(TestEntityOneOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestEntityOneOrMany>(keys.ToArray(), x => x.SecondTestEntityOneOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityOneOrMany?> GetSecondTestEntityOneOrManyRelationship(SecondTestEntityOneOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<SecondTestEntityOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityOneOrManyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}