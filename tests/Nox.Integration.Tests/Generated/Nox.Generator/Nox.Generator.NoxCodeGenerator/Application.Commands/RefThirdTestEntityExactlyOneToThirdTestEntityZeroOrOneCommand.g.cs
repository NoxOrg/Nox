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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand>
{
	public CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetThirdTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToThirdTestEntityZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand>
{
	public DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityZeroOrOneRelationship(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityZeroOrOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToThirdTestEntityZeroOrOne(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(EntityKeyDto);

internal partial class DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand>
{
	public DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetThirdTestEntityExactlyOne(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityExactlyOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToThirdTestEntityZeroOrOne();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand
{
	public IRepository Repository { get; }

	public RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase(
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

	protected async Task<ThirdTestEntityExactlyOneEntity?> GetThirdTestEntityExactlyOne(ThirdTestEntityExactlyOneKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityExactlyOneMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<ThirdTestEntityExactlyOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.ThirdTestEntityZeroOrOne?> GetThirdTestEntityZeroOrOneRelationship(ThirdTestEntityZeroOrOneKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ThirdTestEntityZeroOrOneMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ThirdTestEntityZeroOrOne>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, ThirdTestEntityExactlyOneEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}