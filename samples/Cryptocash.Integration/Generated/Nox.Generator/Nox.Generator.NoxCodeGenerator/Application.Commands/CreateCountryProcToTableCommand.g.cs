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
using CountryProcToTableEntity = CryptocashIntegration.Domain.CountryProcToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record CreateCountryProcToTableCommand(CountryProcToTableCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryProcToTableKeyDto>;

internal partial class CreateCountryProcToTableCommandHandler : CreateCountryProcToTableCommandHandlerBase
{
	public CreateCountryProcToTableCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryProcToTableCommandHandlerBase : CommandBase<CreateCountryProcToTableCommand,CountryProcToTableEntity>, IRequestHandler <CreateCountryProcToTableCommand, CountryProcToTableKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> EntityFactory;

	protected CreateCountryProcToTableCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryProcToTableKeyDto> Handle(CreateCountryProcToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<CryptocashIntegration.Domain.CountryProcToTable>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CountryProcToTableKeyDto(entityToCreate.CountryId.Value);
	}
}