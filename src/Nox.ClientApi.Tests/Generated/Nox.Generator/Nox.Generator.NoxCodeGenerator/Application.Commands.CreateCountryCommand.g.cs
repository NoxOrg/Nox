﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Country = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler: CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> workplacefactory,
        IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,workplacefactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase: CommandBase<CreateCountryCommand,Country>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> _entityFactory;
    private readonly IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> _workplacefactory;

	public CreateCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> workplacefactory,
        IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
        _workplacefactory = workplacefactory;
	}

	public virtual async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.PhysicalWorkplaces)
		{
			var relatedEntity = _workplacefactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToPhysicalWorkplaces(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Countries.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}