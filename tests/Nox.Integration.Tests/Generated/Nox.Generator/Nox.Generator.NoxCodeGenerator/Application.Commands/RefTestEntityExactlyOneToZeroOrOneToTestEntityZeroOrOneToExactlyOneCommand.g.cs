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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityExactlyOneToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToExactlyOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityExactlyOneToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneToExactlyOne(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOneToExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityExactlyOneToZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrOneToExactlyOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand
{
	public IRepository Repository { get; }

	public RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
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

	protected async Task<TestEntityExactlyOneToZeroOrOneEntity?> GetTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestEntityExactlyOneToZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne?> GetTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityZeroOrOneToExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityExactlyOneToZeroOrOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}