// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using TestWebApp.Infrastructure.Persistence;
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand request)
    {
		var entity = await GetThirdTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityExactlyOne",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToThirdTestEntityExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand request)
    {
        var entity = await GetThirdTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetThirdTestEntityExactlyOneRelationship(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("ThirdTestEntityExactlyOne", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToThirdTestEntityExactlyOne(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand request)
    {
        var entity = await GetThirdTestEntityZeroOrOne(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityZeroOrOne",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToThirdTestEntityExactlyOne();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<ThirdTestEntityZeroOrOneEntity?> GetThirdTestEntityZeroOrOne(ThirdTestEntityZeroOrOneKeyDto entityKeyDto)
	{
		var keyId = Dto.ThirdTestEntityZeroOrOneMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(keyId);
	}

	protected async Task<TestWebApp.Domain.ThirdTestEntityExactlyOne?> GetThirdTestEntityExactlyOneRelationship(ThirdTestEntityExactlyOneKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.ThirdTestEntityExactlyOneMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.ThirdTestEntityExactlyOnes.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, ThirdTestEntityZeroOrOneEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}