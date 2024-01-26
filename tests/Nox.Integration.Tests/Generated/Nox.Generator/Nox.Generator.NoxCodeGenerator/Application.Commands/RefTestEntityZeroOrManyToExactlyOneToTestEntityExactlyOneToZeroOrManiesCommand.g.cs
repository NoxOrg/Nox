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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, List<TestEntityExactlyOneToZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityExactlyOneToZeroOrMany(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityExactlyOneToZeroOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityExactlyOneToZeroOrMany(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityExactlyOneToZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrManyToExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityExactlyOneToZeroOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyToExactlyOneEntity?> GetTestEntityZeroOrManyToExactlyOne(TestEntityZeroOrManyToExactlyOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestEntityZeroOrManyToExactlyOne>(keys.ToArray(), x => x.TestEntityExactlyOneToZeroOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany?> GetTestEntityExactlyOneToZeroOrMany(TestEntityExactlyOneToZeroOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityExactlyOneToZeroOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityZeroOrManyToExactlyOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}