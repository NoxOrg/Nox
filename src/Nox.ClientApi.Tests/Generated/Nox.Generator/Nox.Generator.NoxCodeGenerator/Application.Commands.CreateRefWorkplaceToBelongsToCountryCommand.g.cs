
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

public record CreateRefWorkplaceToBelongsToCountryCommand(WorkplaceKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefWorkplaceToBelongsToCountryCommandHandler: CreateRefWorkplaceToBelongsToCountryCommandHandlerBase
{
	public CreateRefWorkplaceToBelongsToCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefWorkplaceToBelongsToCountryCommandHandlerBase: CommandBase<CreateRefWorkplaceToBelongsToCountryCommand, Workplace>, 
	IRequestHandler <CreateRefWorkplaceToBelongsToCountryCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public CreateRefWorkplaceToBelongsToCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefWorkplaceToBelongsToCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Workplace, Nox.Types.Nuid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Country, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCountryBelongsToCountry(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}