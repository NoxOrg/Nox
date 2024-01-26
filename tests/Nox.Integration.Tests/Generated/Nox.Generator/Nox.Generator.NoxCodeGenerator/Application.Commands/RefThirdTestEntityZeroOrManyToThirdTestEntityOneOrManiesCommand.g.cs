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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityOneOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityOneOrMany",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToThirdTestEntityOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, List<ThirdTestEntityOneOrManyKeyDto> RelatedEntitiesKeysDtos)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.ThirdTestEntityOneOrMany>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetThirdTestEntityOneOrManyRelationship(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("ThirdTestEntityOneOrMany", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToThirdTestEntityOneOrManies(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityOneOrManyRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityOneOrMany", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToThirdTestEntityOneOrManies(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto);

internal partial class DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityZeroOrMany(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrMany",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToThirdTestEntityOneOrManies();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand
{
	public IRepository Repository { get; }

	public RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase(
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

	protected async Task<ThirdTestEntityZeroOrManyEntity?> GetThirdTestEntityZeroOrMany(ThirdTestEntityZeroOrManyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityZeroOrManyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<ThirdTestEntityZeroOrMany>(keys.ToArray(), x => x.ThirdTestEntityOneOrManies, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.ThirdTestEntityOneOrMany?> GetThirdTestEntityOneOrManyRelationship(ThirdTestEntityOneOrManyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityOneOrManyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ThirdTestEntityOneOrMany>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, ThirdTestEntityZeroOrManyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}