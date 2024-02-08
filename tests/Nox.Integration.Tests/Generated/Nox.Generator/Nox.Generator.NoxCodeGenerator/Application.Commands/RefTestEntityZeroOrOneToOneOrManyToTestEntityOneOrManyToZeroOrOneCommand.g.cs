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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrOneToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrOneToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityOneOrManyToZeroOrOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityOneOrManyToZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrOneToOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityOneOrManyToZeroOrOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand
{
	public IRepository Repository { get; }

	public RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrOneToOneOrManyEntity?> GetTestEntityZeroOrOneToOneOrMany(TestEntityZeroOrOneToOneOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne?> GetTestEntityOneOrManyToZeroOrOne(TestEntityOneOrManyToZeroOrOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityZeroOrOneToOneOrManyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}