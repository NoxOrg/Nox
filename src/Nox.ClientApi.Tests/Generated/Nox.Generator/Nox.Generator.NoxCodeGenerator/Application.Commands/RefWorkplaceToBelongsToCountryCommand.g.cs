
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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public abstract record RefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToBelongsToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefWorkplaceToBelongsToCountryCommandHandler
	: RefWorkplaceToBelongsToCountryCommandHandlerBase<CreateRefWorkplaceToBelongsToCountryCommand>
{
	public CreateRefWorkplaceToBelongsToCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToBelongsToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefWorkplaceToBelongsToCountryCommandHandler
	: RefWorkplaceToBelongsToCountryCommandHandlerBase<DeleteRefWorkplaceToBelongsToCountryCommand>
{
	public DeleteRefWorkplaceToBelongsToCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto)
	: RefWorkplaceToBelongsToCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefWorkplaceToBelongsToCountryCommandHandler
	: RefWorkplaceToBelongsToCountryCommandHandlerBase<DeleteAllRefWorkplaceToBelongsToCountryCommand>
{
	public DeleteAllRefWorkplaceToBelongsToCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefWorkplaceToBelongsToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, WorkplaceEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToBelongsToCountryCommand
{
	public ClientApiDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefWorkplaceToBelongsToCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.Country? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.CountryMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToBelongsToCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToBelongsToCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToBelongsToCountry();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}