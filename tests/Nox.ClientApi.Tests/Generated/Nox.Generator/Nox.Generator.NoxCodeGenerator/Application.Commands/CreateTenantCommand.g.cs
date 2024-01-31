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
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record CreateTenantCommand(TenantCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TenantKeyDto>;

internal partial class CreateTenantCommandHandler : CreateTenantCommandHandlerBase
{
	public CreateTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(repository, noxSolution,WorkplaceFactory, entityFactory)
	{
	}
}


internal abstract class CreateTenantCommandHandlerBase : CommandBase<CreateTenantCommand,TenantEntity>, IRequestHandler <CreateTenantCommand, TenantKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory;

	protected CreateTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.WorkplaceFactory = WorkplaceFactory;
	}

	public virtual async Task<TenantKeyDto> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.WorkplacesId.Any())
		{
			foreach(var relatedId in request.EntityDto.WorkplacesId)
			{
				var relatedKey = Dto.WorkplaceMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<Workplace>(relatedKey);

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
		await Repository.AddAsync<Tenant>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new TenantKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateTenantValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantValidator()
    {
		RuleFor(x => x.EntityDto.TenantBrands)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("TenantBrands.Id must be null as it is auto generated.");
    }
}