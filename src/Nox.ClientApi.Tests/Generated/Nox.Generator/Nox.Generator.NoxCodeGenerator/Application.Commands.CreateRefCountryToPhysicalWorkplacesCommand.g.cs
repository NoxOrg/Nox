
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

public record CreateRefCountryToPhysicalWorkplacesCommand(CountryKeyDto EntityKeyDto, WorkplaceKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCountryToPhysicalWorkplacesCommandHandler: CreateRefCountryToPhysicalWorkplacesCommandHandlerBase
{
	public CreateRefCountryToPhysicalWorkplacesCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefCountryToPhysicalWorkplacesCommandHandlerBase: CommandBase<CreateRefCountryToPhysicalWorkplacesCommand, Country>, 
	IRequestHandler <CreateRefCountryToPhysicalWorkplacesCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public CreateRefCountryToPhysicalWorkplacesCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefCountryToPhysicalWorkplacesCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Workplace, Nox.Types.Nuid>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Workplaces.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToWorkplacePhysicalWorkplaces(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}