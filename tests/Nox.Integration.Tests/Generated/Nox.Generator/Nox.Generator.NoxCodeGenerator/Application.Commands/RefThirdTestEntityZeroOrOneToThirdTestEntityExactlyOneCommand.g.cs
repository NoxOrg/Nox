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
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand>
{
	public CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetThirdTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToThirdTestEntityExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand>
{
	public DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToThirdTestEntityExactlyOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(EntityKeyDto);

internal partial class DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand>
{
	public DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityZeroOrOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToThirdTestEntityExactlyOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand
{
	public IRepository Repository { get; }

	public RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase(
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

	protected async Task<ThirdTestEntityZeroOrOneEntity?> GetThirdTestEntityZeroOrOne(ThirdTestEntityZeroOrOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityZeroOrOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<ThirdTestEntityZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.ThirdTestEntityExactlyOne?> GetThirdTestEntityExactlyOneRelationship(ThirdTestEntityExactlyOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ThirdTestEntityExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, ThirdTestEntityZeroOrOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}