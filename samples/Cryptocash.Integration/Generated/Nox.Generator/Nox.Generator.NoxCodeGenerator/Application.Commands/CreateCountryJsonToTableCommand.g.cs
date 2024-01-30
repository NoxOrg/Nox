﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryJsonToTableEntity = CryptocashIntegration.Domain.CountryJsonToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record CreateCountryJsonToTableCommand(CountryJsonToTableCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryJsonToTableKeyDto>;

internal partial class CreateCountryJsonToTableCommandHandler : CreateCountryJsonToTableCommandHandlerBase
{
	public CreateCountryJsonToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryJsonToTableCommandHandlerBase : CommandBase<CreateCountryJsonToTableCommand,CountryJsonToTableEntity>, IRequestHandler <CreateCountryJsonToTableCommand, CountryJsonToTableKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> EntityFactory;

	protected CreateCountryJsonToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryJsonToTableKeyDto> Handle(CreateCountryJsonToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<CountryJsonToTable>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CountryJsonToTableKeyDto(entityToCreate.Id.Value);
	}
}