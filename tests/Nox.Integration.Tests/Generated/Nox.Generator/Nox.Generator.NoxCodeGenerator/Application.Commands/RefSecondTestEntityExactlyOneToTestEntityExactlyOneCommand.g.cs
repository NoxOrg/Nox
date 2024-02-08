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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityExactlyOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase(
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

	protected async Task<SecondTestEntityExactlyOneEntity?> GetSecondTestEntityExactlyOne(SecondTestEntityExactlyOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityExactlyOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityExactlyOne?> GetTestEntityExactlyOneRelationship(TestEntityExactlyOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestWebApp.Domain.TestEntityExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, SecondTestEntityExactlyOneEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}