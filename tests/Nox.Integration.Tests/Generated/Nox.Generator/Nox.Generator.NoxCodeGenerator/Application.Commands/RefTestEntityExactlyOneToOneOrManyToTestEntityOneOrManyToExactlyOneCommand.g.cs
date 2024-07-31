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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityExactlyOneToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToExactlyOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityExactlyOneToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToExactlyOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityOneOrManyToExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityExactlyOneToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityOneOrManyToExactlyOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand
{
	public IRepository Repository { get; }

	public RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase(
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

	protected async Task<TestEntityExactlyOneToOneOrManyEntity?> GetTestEntityExactlyOneToOneOrMany(TestEntityExactlyOneToOneOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityExactlyOneToOneOrManyMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne?> GetTestEntityOneOrManyToExactlyOne(TestEntityOneOrManyToExactlyOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyToExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityExactlyOneToOneOrManyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}