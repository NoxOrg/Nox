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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToZeroOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOneToZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, List<TestEntityZeroOrOneToZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityZeroOrOneToZeroOrMany(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityZeroOrOneToZeroOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToZeroOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOneToZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrManyToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrOneToZeroOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyToZeroOrOneEntity?> GetTestEntityZeroOrManyToZeroOrOne(TestEntityZeroOrManyToZeroOrOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne>(keys.ToArray(), x => x.TestEntityZeroOrOneToZeroOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany?> GetTestEntityZeroOrOneToZeroOrMany(TestEntityZeroOrOneToZeroOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityZeroOrManyToZeroOrOneEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}