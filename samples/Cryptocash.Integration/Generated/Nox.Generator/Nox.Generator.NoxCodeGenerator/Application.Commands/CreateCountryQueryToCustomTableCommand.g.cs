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
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record CreateCountryQueryToCustomTableCommand(CountryQueryToCustomTableCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryQueryToCustomTableKeyDto>;

internal partial class CreateCountryQueryToCustomTableCommandHandler : CreateCountryQueryToCustomTableCommandHandlerBase
{
	public CreateCountryQueryToCustomTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryQueryToCustomTableCommandHandlerBase : CommandBase<CreateCountryQueryToCustomTableCommand,CountryQueryToCustomTableEntity>, IRequestHandler <CreateCountryQueryToCustomTableCommand, CountryQueryToCustomTableKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> EntityFactory;

	protected CreateCountryQueryToCustomTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToCustomTableKeyDto> Handle(CreateCountryQueryToCustomTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<CryptocashIntegration.Domain.CountryQueryToCustomTable>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CountryQueryToCustomTableKeyDto(entityToCreate.Id.Value);
	}
}