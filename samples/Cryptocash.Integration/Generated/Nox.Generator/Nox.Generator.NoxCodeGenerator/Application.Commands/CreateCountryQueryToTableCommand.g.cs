﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using CryptocashIntegration.Infrastructure.Persistence;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record CreateCountryQueryToTableCommand(CountryQueryToTableCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryQueryToTableKeyDto>;

internal partial class CreateCountryQueryToTableCommandHandler : CreateCountryQueryToTableCommandHandlerBase
{
	public CreateCountryQueryToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryQueryToTableCommandHandlerBase : CommandBase<CreateCountryQueryToTableCommand,CountryQueryToTableEntity>, IRequestHandler <CreateCountryQueryToTableCommand, CountryQueryToTableKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> EntityFactory;

	protected CreateCountryQueryToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToTableKeyDto> Handle(CreateCountryQueryToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<CountryQueryToTable>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CountryQueryToTableKeyDto(entityToCreate.Id.Value);
	}
}