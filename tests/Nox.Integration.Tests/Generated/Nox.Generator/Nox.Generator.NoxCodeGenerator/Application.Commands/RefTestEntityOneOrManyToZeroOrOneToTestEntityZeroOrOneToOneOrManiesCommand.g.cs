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
using TestEntityOneOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToOneOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOneToOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, List<TestEntityZeroOrOneToOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityZeroOrOneToOneOrMany(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityZeroOrOneToOneOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToOneOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOneToOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrOneToOneOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityOneOrManyToZeroOrOneEntity?> GetTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestEntityOneOrManyToZeroOrOne>(keys.ToArray(), x => x.TestEntityZeroOrOneToOneOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany?> GetTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityZeroOrOneToOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityOneOrManyToZeroOrOneEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}