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
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Commands;

public partial record CreateCurrencyCommand(CurrencyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CurrencyKeyDto>;

internal partial class CreateCurrencyCommandHandler : CreateCurrencyCommandHandlerBase
{
	public CreateCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,StoreLicenseFactory, entityFactory)
	{
	}
}


internal abstract class CreateCurrencyCommandHandlerBase : CommandBase<CreateCurrencyCommand,CurrencyEntity>, IRequestHandler <CreateCurrencyCommand, CurrencyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory;

	protected CreateCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.StoreLicenseFactory = StoreLicenseFactory;
	}

	public virtual async Task<CurrencyKeyDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.StoreLicenseDefaultId.Any())
		{
			foreach(var relatedId in request.EntityDto.StoreLicenseDefaultId)
			{
				var relatedKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKey);

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
				var relatedEntity = StoreLicenseFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToStoreLicenseDefault(relatedEntity);
			}
		}
		if(request.EntityDto.StoreLicenseSoldInId.Any())
		{
			foreach(var relatedId in request.EntityDto.StoreLicenseSoldInId)
			{
				var relatedKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKey);

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
				var relatedEntity = StoreLicenseFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToStoreLicenseSoldIn(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Currencies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entityToCreate.Id.Value);
	}
}