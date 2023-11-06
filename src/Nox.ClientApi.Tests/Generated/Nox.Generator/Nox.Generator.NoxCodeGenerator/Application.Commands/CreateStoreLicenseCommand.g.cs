﻿﻿// Generated

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

public partial record CreateStoreLicenseCommand(StoreLicenseCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<StoreLicenseKeyDto>;

internal partial class CreateStoreLicenseCommandHandler : CreateStoreLicenseCommandHandlerBase
{
	public CreateStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(dbContext, noxSolution,StoreFactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreLicenseCommandHandlerBase : CommandBase<CreateStoreLicenseCommand,StoreLicenseEntity>, IRequestHandler <CreateStoreLicenseCommand, StoreLicenseKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory;

	public CreateStoreLicenseCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.StoreFactory = StoreFactory;
	}

	public virtual async Task<StoreLicenseKeyDto> Handle(CreateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.StoreId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreMetadata.CreateId(request.EntityDto.StoreId.NonNullValue<System.Guid>());
			var relatedEntity = await DbContext.Stores.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToStore(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Store", request.EntityDto.StoreId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Store is not null)
		{
			var relatedEntity = StoreFactory.CreateEntity(request.EntityDto.Store);
			entityToCreate.CreateRefToStore(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.StoreLicenses.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreLicenseKeyDto(entityToCreate.Id.Value);
	}
}