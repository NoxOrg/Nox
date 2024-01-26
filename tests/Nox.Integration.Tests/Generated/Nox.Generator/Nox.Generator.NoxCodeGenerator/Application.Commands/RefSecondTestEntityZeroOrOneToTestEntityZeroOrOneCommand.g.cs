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
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase(
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

	protected async Task<SecondTestEntityZeroOrOneEntity?> GetSecondTestEntityZeroOrOne(SecondTestEntityZeroOrOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityZeroOrOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<SecondTestEntityZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrOne?> GetTestEntityZeroOrOneRelationship(TestEntityZeroOrOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, SecondTestEntityZeroOrOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}