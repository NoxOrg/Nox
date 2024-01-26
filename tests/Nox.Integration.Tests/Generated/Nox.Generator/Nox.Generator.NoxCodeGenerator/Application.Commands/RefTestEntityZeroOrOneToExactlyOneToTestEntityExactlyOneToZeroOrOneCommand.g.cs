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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrOneToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrOneToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityExactlyOneToZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(TestEntityZeroOrOneToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrOneToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityExactlyOneToZeroOrOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand
{
	public IRepository Repository { get; }

	public RefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrOneToExactlyOneEntity?> GetTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestEntityZeroOrOneToExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne?> GetTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityExactlyOneToZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityZeroOrOneToExactlyOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}