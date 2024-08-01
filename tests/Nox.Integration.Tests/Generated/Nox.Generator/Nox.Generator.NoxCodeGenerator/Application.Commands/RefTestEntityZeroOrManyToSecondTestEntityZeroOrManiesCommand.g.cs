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
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToSecondTestEntityZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, List<SecondTestEntityZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.SecondTestEntityZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetSecondTestEntityZeroOrManyRelationship(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToSecondTestEntityZeroOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetSecondTestEntityZeroOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("SecondTestEntityZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToSecondTestEntityZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToSecondTestEntityZeroOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand
{
	public IRepository Repository { get; }

	public RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase(
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

	protected async Task<TestEntityZeroOrManyEntity?> GetTestEntityZeroOrMany(TestEntityZeroOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<TestWebApp.Domain.TestEntityZeroOrMany>(keys.ToArray(), x => x.SecondTestEntityZeroOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.SecondTestEntityZeroOrMany?> GetSecondTestEntityZeroOrManyRelationship(SecondTestEntityZeroOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestWebApp.Domain.SecondTestEntityZeroOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, TestEntityZeroOrManyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}