
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public abstract record RefCountryToPhysicalWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToPhysicalWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefCountryToPhysicalWorkplacesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToPhysicalWorkplacesCommandHandler
	: RefCountryToPhysicalWorkplacesCommandHandlerBase<CreateRefCountryToPhysicalWorkplacesCommand>
{
	public CreateRefCountryToPhysicalWorkplacesCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToPhysicalWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto)
	: RefCountryToPhysicalWorkplacesCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCountryToPhysicalWorkplacesCommandHandler
	: RefCountryToPhysicalWorkplacesCommandHandlerBase<DeleteRefCountryToPhysicalWorkplacesCommand>
{
	public DeleteRefCountryToPhysicalWorkplacesCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToPhysicalWorkplacesCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToPhysicalWorkplacesCommand(EntityKeyDto, null);

public partial class DeleteAllRefCountryToPhysicalWorkplacesCommandHandler
	: RefCountryToPhysicalWorkplacesCommandHandlerBase<DeleteAllRefCountryToPhysicalWorkplacesCommand>
{
	public DeleteAllRefCountryToPhysicalWorkplacesCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

public abstract class RefCountryToPhysicalWorkplacesCommandHandlerBase<TRequest>: CommandBase<TRequest, Country>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToPhysicalWorkplacesCommand
{
	public ClientApiDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToPhysicalWorkplacesCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Workplace? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Workplace, Nox.Types.Nuid>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Workplaces.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToPhysicalWorkplaces(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToPhysicalWorkplaces(relatedEntity);
                break;
            case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.PhysicalWorkplaces).LoadAsync();
                entity.DeleteAllRefToPhysicalWorkplaces();
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}