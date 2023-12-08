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
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Commands;

public partial record CreateCountryQueryToTableCommand(CountryQueryToTableCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryQueryToTableKeyDto>;

internal partial class CreateCountryQueryToTableCommandHandler : CreateCountryQueryToTableCommandHandlerBase
{
	public CreateCountryQueryToTableCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryQueryToTableCommandHandlerBase : CommandBase<CreateCountryQueryToTableCommand,CountryQueryToTableEntity>, IRequestHandler <CreateCountryQueryToTableCommand, CountryQueryToTableKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> EntityFactory;

	public CreateCountryQueryToTableCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToTableKeyDto> Handle(CreateCountryQueryToTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.CountryQueryToTables.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryQueryToTableKeyDto(entityToCreate.Id.Value);
	}
}