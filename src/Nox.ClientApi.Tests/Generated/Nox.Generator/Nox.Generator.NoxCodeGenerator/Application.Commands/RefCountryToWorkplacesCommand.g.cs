
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
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public abstract record RefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefCountryToWorkplacesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToWorkplacesCommandHandler
	: RefCountryToWorkplacesCommandHandlerBase<CreateRefCountryToWorkplacesCommand>
{
	public CreateRefCountryToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefCountryToWorkplacesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToWorkplacesCommandHandler
	: RefCountryToWorkplacesCommandHandlerBase<DeleteRefCountryToWorkplacesCommand>
{
	public DeleteRefCountryToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToWorkplacesCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToWorkplacesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToWorkplacesCommandHandler
	: RefCountryToWorkplacesCommandHandlerBase<DeleteAllRefCountryToWorkplacesCommand>
{
	public DeleteAllRefCountryToWorkplacesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToWorkplacesCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToWorkplacesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToWorkplacesCommandHandlerBase(
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
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.Workplace? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.WorkplaceMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Workplaces.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToWorkplaces(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToWorkplaces(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Workplaces).LoadAsync();
				entity.DeleteAllRefToWorkplaces();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}