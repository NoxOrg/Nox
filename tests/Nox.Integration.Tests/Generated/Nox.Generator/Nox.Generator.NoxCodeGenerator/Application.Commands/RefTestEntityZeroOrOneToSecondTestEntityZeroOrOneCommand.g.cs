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
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSecondTestEntityZeroOrOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand
{
	public IRepository Repository { get; }

	public RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrOneEntity?> GetTestEntityZeroOrOne(TestEntityZeroOrOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestEntityZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityZeroOrOne?> GetSecondTestEntityZeroOrOneRelationship(SecondTestEntityZeroOrOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<SecondTestEntityZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityZeroOrOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}