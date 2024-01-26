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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityZeroOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToThirdTestEntityZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, List<ThirdTestEntityZeroOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.ThirdTestEntityZeroOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetThirdTestEntityZeroOrManyRelationship(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToThirdTestEntityZeroOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityZeroOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToThirdTestEntityZeroOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityOneOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToThirdTestEntityZeroOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand
{
	public IRepository Repository { get; }

	public RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase(
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

	protected async Task<ThirdTestEntityOneOrManyEntity?> GetThirdTestEntityOneOrMany(ThirdTestEntityOneOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityOneOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<ThirdTestEntityOneOrMany>(keys.ToArray(), x => x.ThirdTestEntityZeroOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.ThirdTestEntityZeroOrMany?> GetThirdTestEntityZeroOrManyRelationship(ThirdTestEntityZeroOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityZeroOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ThirdTestEntityZeroOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, ThirdTestEntityOneOrManyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}