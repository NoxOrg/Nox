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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Country = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public record CreateCountryCommand(CountryCreateDto EntityDto) : IRequest<CountryKeyDto>;

public partial class CreateCountryCommandHandler: CommandBase<CreateCountryCommand,Country>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CountryCreateDto,Country> _entityFactory;

	public CreateCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<CountryCreateDto,Country> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);		
	
		OnCompleted(entityToCreate);
		_dbContext.Countries.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}