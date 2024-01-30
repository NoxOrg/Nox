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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrManyToZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrManyToOneOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, List<TestEntityZeroOrManyToOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<UpdateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand>
{
	public UpdateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityOneOrManyToZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityZeroOrManyToOneOrMany(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityZeroOrManyToOneOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrManyToZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrManyToOneOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityOneOrManyToZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrManyToOneOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityOneOrManyToZeroOrManyEntity?> GetTestEntityOneOrManyToZeroOrMany(TestEntityOneOrManyToZeroOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestEntityOneOrManyToZeroOrMany>(keys.ToArray(), x => x.TestEntityZeroOrManyToOneOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany?> GetTestEntityZeroOrManyToOneOrMany(TestEntityZeroOrManyToOneOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityZeroOrManyToOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityOneOrManyToZeroOrManyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}