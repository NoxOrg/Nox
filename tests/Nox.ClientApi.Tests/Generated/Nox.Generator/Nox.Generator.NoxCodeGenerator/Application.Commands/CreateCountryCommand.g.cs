﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record CreateCountryCommand(CountryCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler : CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(dbContext, noxSolution,WorkplaceFactory, entityFactory)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase : CommandBase<CreateCountryCommand,CountryEntity>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory;

	protected CreateCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.WorkplaceFactory = WorkplaceFactory;
	}

	public virtual async Task<CountryKeyDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.WorkplacesId.Any())
		{
			foreach(var relatedId in request.EntityDto.WorkplacesId)
			{
				var relatedKey = ClientApi.Domain.WorkplaceMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Workplaces.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToWorkplaces(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Workplaces", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Workplaces)
			{
				var relatedEntity = await WorkplaceFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToWorkplaces(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Countries.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CountryKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
		RuleFor(x => x.EntityDto.CountryLocalNames)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("CountryLocalNames.Id must be null as it is auto generated.");
		RuleFor(x => x.EntityDto.CountryTimeZones)
			.Must(owned => owned.All(x => x.Id != null))
			.WithMessage("CountryTimeZones.Id is required."); 
    }
}