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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToTestEntityZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, List<TestEntityZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.TestEntityZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTestEntityZeroOrManyRelationship(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("TestEntityZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToTestEntityZeroOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTestEntityZeroOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("TestEntityZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToTestEntityZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetSecondTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToTestEntityZeroOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand
{
	public IRepository Repository { get; }

	public RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase(
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

	protected async Task<SecondTestEntityZeroOrManyEntity?> GetSecondTestEntityZeroOrMany(SecondTestEntityZeroOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.SecondTestEntityZeroOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<SecondTestEntityZeroOrMany>(keys.ToArray(), x => x.TestEntityZeroOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.TestEntityZeroOrMany?> GetTestEntityZeroOrManyRelationship(TestEntityZeroOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.TestEntityZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<TestEntityZeroOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, SecondTestEntityZeroOrManyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}