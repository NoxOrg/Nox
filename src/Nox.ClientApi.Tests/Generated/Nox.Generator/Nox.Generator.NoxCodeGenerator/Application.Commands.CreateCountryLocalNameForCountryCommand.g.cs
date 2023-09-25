﻿// Generated

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
using CountryLocalName = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public record CreateCountryLocalNameForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameCreateDto EntityDto, System.Guid? Etag) : IRequest <CountryLocalNameKeyDto?>;

internal partial class CreateCountryLocalNameForCountryCommandHandler: CreateCountryLocalNameForCountryCommandHandlerBase
{
	public CreateCountryLocalNameForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution, entityFactory, serviceProvider)
	{
	}
}
internal abstract class CreateCountryLocalNameForCountryCommandHandlerBase: CommandBase<CreateCountryLocalNameForCountryCommand, CountryLocalName>, IRequestHandler<CreateCountryLocalNameForCountryCommand, CountryLocalNameKeyDto?>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> _entityFactory;

	public CreateCountryLocalNameForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<CountryLocalNameKeyDto?> Handle(CreateCountryLocalNameForCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,Nox.Types.AutoNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		parentEntity.CountryShortNames.Add(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}