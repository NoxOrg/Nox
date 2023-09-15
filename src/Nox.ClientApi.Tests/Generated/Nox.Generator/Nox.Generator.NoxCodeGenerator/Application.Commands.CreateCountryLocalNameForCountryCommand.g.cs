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

public partial class CreateCountryLocalNameForCountryCommandHandler: CommandBase<CreateCountryLocalNameForCountryCommand, CountryLocalName>, IRequestHandler<CreateCountryLocalNameForCountryCommand, CountryLocalNameKeyDto?>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<CountryLocalName,CountryLocalNameCreateDto> _entityFactory;

	public CreateCountryLocalNameForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryLocalName,CountryLocalNameCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public async Task<CountryLocalNameKeyDto?> Handle(CreateCountryLocalNameForCountryCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,AutoNumber>("Id", request.ParentKeyDto.keyId);

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