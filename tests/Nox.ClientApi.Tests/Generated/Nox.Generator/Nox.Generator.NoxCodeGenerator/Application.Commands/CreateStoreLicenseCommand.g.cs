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

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public partial record CreateStoreLicenseCommand(StoreLicenseCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<StoreLicenseKeyDto>;

internal partial class CreateStoreLicenseCommandHandler : CreateStoreLicenseCommandHandlerBase
{
	public CreateStoreLicenseCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<ClientApi.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(repository, noxSolution,StoreFactory, CurrencyFactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreLicenseCommandHandlerBase : CommandBase<CreateStoreLicenseCommand,StoreLicenseEntity>, IRequestHandler <CreateStoreLicenseCommand, StoreLicenseKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory;

	protected CreateStoreLicenseCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<ClientApi.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.StoreFactory = StoreFactory;
		this.CurrencyFactory = CurrencyFactory;
	}

	public virtual async Task<StoreLicenseKeyDto> Handle(CreateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.StoreId is not null)
		{
			var relatedKey = Dto.StoreMetadata.CreateId(request.EntityDto.StoreId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Store>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToStore(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Store", request.EntityDto.StoreId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Store is not null)
		{
			var relatedEntity = await StoreFactory.CreateEntityAsync(request.EntityDto.Store, request.CultureCode);
			entityToCreate.CreateRefToStore(relatedEntity);
		}
		if(request.EntityDto.DefaultCurrencyId is not null)
		{
			var relatedKey = Dto.CurrencyMetadata.CreateId(request.EntityDto.DefaultCurrencyId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<Currency>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToDefaultCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("DefaultCurrency", request.EntityDto.DefaultCurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.DefaultCurrency is not null)
		{
			var relatedEntity = await CurrencyFactory.CreateEntityAsync(request.EntityDto.DefaultCurrency, request.CultureCode);
			entityToCreate.CreateRefToDefaultCurrency(relatedEntity);
		}
		if(request.EntityDto.SoldInCurrencyId is not null)
		{
			var relatedKey = Dto.CurrencyMetadata.CreateId(request.EntityDto.SoldInCurrencyId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<Currency>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToSoldInCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("SoldInCurrency", request.EntityDto.SoldInCurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.SoldInCurrency is not null)
		{
			var relatedEntity = await CurrencyFactory.CreateEntityAsync(request.EntityDto.SoldInCurrency, request.CultureCode);
			entityToCreate.CreateRefToSoldInCurrency(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<StoreLicense>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new StoreLicenseKeyDto(entityToCreate.Id.Value);
	}
}