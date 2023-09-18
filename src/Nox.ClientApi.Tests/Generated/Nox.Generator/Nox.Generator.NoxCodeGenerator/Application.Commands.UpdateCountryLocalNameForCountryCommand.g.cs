// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;
public record UpdateCountryLocalNameForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto, CountryLocalNameUpdateDto EntityDto, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto?>;

public partial class UpdateCountryLocalNameForCountryCommandHandler: UpdateCountryLocalNameForCountryCommandHandlerBase
{
	public UpdateCountryLocalNameForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryLocalName> entityMapper): base(dbContext ,noxSolution, serviceProvider, entityMapper)
	{
	}
}
public abstract class UpdateCountryLocalNameForCountryCommandHandlerBase: CommandBase<UpdateCountryLocalNameForCountryCommand, CountryLocalName>, IRequestHandler <UpdateCountryLocalNameForCountryCommand, CountryLocalNameKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<CountryLocalName> EntityMapper { get; }

	public UpdateCountryLocalNameForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CountryLocalName> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public virtual async Task<CountryLocalNameKeyDto?> Handle(UpdateCountryLocalNameForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<CountryLocalName,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryShortNames.SingleOrDefault(x => x.Id == ownedId);		
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<CountryLocalName>(), request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}