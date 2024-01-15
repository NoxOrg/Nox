﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using FluentValidation;
using Microsoft.Extensions.Logging;

using CryptocashIntegration.Infrastructure.Persistence;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Application.Dto;
using Dto = CryptocashIntegration.Application.Dto;
using CountryJsonToTableEntity = CryptocashIntegration.Domain.CountryJsonToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record CreateCountryJsonToTableCommand(CountryJsonToTableCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryJsonToTableKeyDto>;

internal partial class CreateCountryJsonToTableCommandHandler : CreateCountryJsonToTableCommandHandlerBase
{
	public CreateCountryJsonToTableCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryJsonToTableCommandHandlerBase : CommandBase<CreateCountryJsonToTableCommand,CountryJsonToTableEntity>, IRequestHandler <CreateCountryJsonToTableCommand, CountryJsonToTableKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> EntityFactory;

	protected CreateCountryJsonToTableCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryJsonToTableKeyDto> Handle(CreateCountryJsonToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.CountryJsonToTables.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryJsonToTableKeyDto(entityToCreate.Id.Value);
	}
}