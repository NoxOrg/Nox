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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityOneOrManyToZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, List<TestEntityOneOrManyToZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityOneOrManyToZeroOrMany(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityOneOrManyToZeroOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityOneOrManyToZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrManyToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityOneOrManyToZeroOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyToOneOrManyEntity?> GetTestEntityZeroOrManyToOneOrMany(TestEntityZeroOrManyToOneOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany>(keys.ToArray(), x => x.TestEntityOneOrManyToZeroOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany?> GetTestEntityOneOrManyToZeroOrMany(TestEntityOneOrManyToZeroOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityZeroOrManyToOneOrManyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}