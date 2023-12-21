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
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Commands;

public partial record CreateCountryQueryToCustomTableCommand(CountryQueryToCustomTableCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryQueryToCustomTableKeyDto>;

internal partial class CreateCountryQueryToCustomTableCommandHandler : CreateCountryQueryToCustomTableCommandHandlerBase
{
	public CreateCountryQueryToCustomTableCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateCountryQueryToCustomTableCommandHandlerBase : CommandBase<CreateCountryQueryToCustomTableCommand,CountryQueryToCustomTableEntity>, IRequestHandler <CreateCountryQueryToCustomTableCommand, CountryQueryToCustomTableKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> EntityFactory;

	protected CreateCountryQueryToCustomTableCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CountryQueryToCustomTableKeyDto> Handle(CreateCountryQueryToCustomTableCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.CountryQueryToCustomTables.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryQueryToCustomTableKeyDto(entityToCreate.Id.Value);
	}
}