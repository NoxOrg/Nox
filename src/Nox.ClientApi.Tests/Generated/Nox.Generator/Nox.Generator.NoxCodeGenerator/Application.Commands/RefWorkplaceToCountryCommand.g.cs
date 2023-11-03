
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

public abstract record RefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefWorkplaceToCountryCommandHandler
	: RefWorkplaceToCountryCommandHandlerBase<CreateRefWorkplaceToCountryCommand>
{
	public CreateRefWorkplaceToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefWorkplaceToCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefWorkplaceToCountryCommandHandler
	: RefWorkplaceToCountryCommandHandlerBase<DeleteRefWorkplaceToCountryCommand>
{
	public DeleteRefWorkplaceToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefWorkplaceToCountryCommand(WorkplaceKeyDto EntityKeyDto)
	: RefWorkplaceToCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefWorkplaceToCountryCommandHandler
	: RefWorkplaceToCountryCommandHandlerBase<DeleteAllRefWorkplaceToCountryCommand>
{
	public DeleteAllRefWorkplaceToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefWorkplaceToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, WorkplaceEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefWorkplaceToCountryCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefWorkplaceToCountryCommandHandlerBase(
        AppDbContext dbContext,
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
		await OnExecutingAsync(request);
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
				entity.CreateRefToCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCountry();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}