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
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Commands;

public partial record CreateCurrencyCommand(CurrencyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CurrencyKeyDto>;

internal partial class CreateCurrencyCommandHandler : CreateCurrencyCommandHandlerBase
{
	public CreateCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(repository, noxSolution,StoreLicenseFactory, entityFactory)
	{
	}
}


internal abstract class CreateCurrencyCommandHandlerBase : CommandBase<CreateCurrencyCommand,CurrencyEntity>, IRequestHandler <CreateCurrencyCommand, CurrencyKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory;

	protected CreateCurrencyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.StoreLicenseFactory = StoreLicenseFactory;
	}

	public virtual async Task<CurrencyKeyDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.StoreLicenseDefaultId.Any())
		{
			foreach(var relatedId in request.EntityDto.StoreLicenseDefaultId)
			{
				var relatedKey = Dto.StoreLicenseMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<StoreLicense>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToStoreLicenseDefault(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("StoreLicenseDefault", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.StoreLicenseDefault)
			{
				var relatedEntity = await StoreLicenseFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToStoreLicenseDefault(relatedEntity);
			}
		}
		if(request.EntityDto.StoreLicenseSoldInId.Any())
		{
			foreach(var relatedId in request.EntityDto.StoreLicenseSoldInId)
			{
				var relatedKey = Dto.StoreLicenseMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<StoreLicense>(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToStoreLicenseSoldIn(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("StoreLicenseSoldIn", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.StoreLicenseSoldIn)
			{
				var relatedEntity = await StoreLicenseFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToStoreLicenseSoldIn(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Currency>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CurrencyKeyDto(entityToCreate.Id.Value);
	}
}