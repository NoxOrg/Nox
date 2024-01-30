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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToOneOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityExactlyOneToOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, List<TestEntityExactlyOneToOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<UpdateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand>
{
	public UpdateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityExactlyOneToOneOrMany(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneToOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityExactlyOneToOneOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToOneOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityExactlyOneToOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityExactlyOneToOneOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityOneOrManyToExactlyOneEntity?> GetTestEntityOneOrManyToExactlyOne(TestEntityOneOrManyToExactlyOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyToExactlyOneMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestEntityOneOrManyToExactlyOne>(keys.ToArray(), x => x.TestEntityExactlyOneToOneOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany?> GetTestEntityExactlyOneToOneOrMany(TestEntityExactlyOneToOneOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityExactlyOneToOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityExactlyOneToOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityOneOrManyToExactlyOneEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}