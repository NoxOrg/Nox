﻿﻿// Generated

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

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public partial record CreateCountryCommand(CountryCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CountryKeyDto>;

internal partial class CreateCountryCommandHandler : CreateCountryCommandHandlerBase
{
	public CreateCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
		: base(repository, noxSolution,WorkplaceFactory, StoreFactory, entityFactory)
	{
	}
}


internal abstract class CreateCountryCommandHandlerBase : CommandBase<CreateCountryCommand,CountryEntity>, IRequestHandler <CreateCountryCommand, CountryKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory;

	protected CreateCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.WorkplaceFactory = WorkplaceFactory;
		this.StoreFactory = StoreFactory;
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
				var relatedKey = Dto.WorkplaceMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<ClientApi.Domain.Workplace>(relatedKey);

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
		if(request.EntityDto.StoresId.Any())
		{
			foreach(var relatedId in request.EntityDto.StoresId)
			{
				var relatedKey = Dto.StoreMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<ClientApi.Domain.Store>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToStores(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Stores", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Stores)
			{
				var relatedEntity = await StoreFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToStores(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<ClientApi.Domain.Country>(entityToCreate);
		await Repository.SaveChangesAsync();
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