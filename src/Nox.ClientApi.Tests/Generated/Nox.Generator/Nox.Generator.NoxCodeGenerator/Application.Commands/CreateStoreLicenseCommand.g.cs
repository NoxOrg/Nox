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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public record CreateStoreLicenseCommand(StoreLicenseCreateDto EntityDto) : IRequest<StoreLicenseKeyDto>;

internal partial class CreateStoreLicenseCommandHandler : CreateStoreLicenseCommandHandlerBase
{
	public CreateStoreLicenseCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> storefactory,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(dbContext, noxSolution,storefactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreLicenseCommandHandlerBase : CommandBase<CreateStoreLicenseCommand,StoreLicenseEntity>, IRequestHandler <CreateStoreLicenseCommand, StoreLicenseKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> _entityFactory;
	private readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> _storefactory;

	public CreateStoreLicenseCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> storefactory,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_storefactory = storefactory;
	}

	public virtual async Task<StoreLicenseKeyDto> Handle(CreateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.StoreWithLicenseId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreMetadata.CreateId(request.EntityDto.StoreWithLicenseId.NonNullValue<System.Guid>());
			var relatedEntity = await _dbContext.Stores.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToStoreWithLicense(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("StoreWithLicense", request.EntityDto.StoreWithLicenseId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.StoreWithLicense is not null)
		{
			var relatedEntity = _storefactory.CreateEntity(request.EntityDto.StoreWithLicense);
			entityToCreate.CreateRefToStoreWithLicense(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.StoreLicenses.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new StoreLicenseKeyDto(entityToCreate.Id.Value);
	}
}