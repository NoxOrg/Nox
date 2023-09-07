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
public record AddCountryLocalNameCommand(CountryKeyDto ParentKeyDto, CountryLocalNameCreateDto EntityDto) : IRequest <CountryLocalNameKeyDto?>;

public partial class AddCountryLocalNameCommandHandler: CommandBase<AddCountryLocalNameCommand, CountryLocalName>, IRequestHandler <AddCountryLocalNameCommand, CountryLocalNameKeyDto?>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<CountryLocalNameCreateDto,CountryLocalName> _entityFactory;

	public AddCountryLocalNameCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryLocalNameCreateDto,CountryLocalName> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;	
	}

	public async Task<CountryLocalNameKeyDto?> Handle(AddCountryLocalNameCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,DatabaseNumber>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await _dbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);
		
		parentEntity.CountryLocalNames.Add(entity);

		OnCompleted(entity);
	
		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CountryLocalNameKeyDto(entity.Id.Value);
	}
}