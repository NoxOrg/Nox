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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto, SecondTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto, SecondTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSecondTestEntityExactlyOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand
{
	public IRepository Repository { get; }

	public RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase(
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

	protected async Task<TestEntityExactlyOneEntity?> GetTestEntityExactlyOne(TestEntityExactlyOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityExactlyOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestEntityExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityExactlyOne?> GetSecondTestEntityExactlyOneRelationship(SecondTestEntityExactlyOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<SecondTestEntityExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityExactlyOneEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}