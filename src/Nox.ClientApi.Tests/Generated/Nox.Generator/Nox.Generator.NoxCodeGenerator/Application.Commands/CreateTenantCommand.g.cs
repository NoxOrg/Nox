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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record CreateTenantCommand(TenantCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<TenantKeyDto>;

internal partial class CreateTenantCommandHandler : CreateTenantCommandHandlerBase
{
	public CreateTenantCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(dbContext, noxSolution,WorkplaceFactory, entityFactory)
	{
	}
}


internal abstract class CreateTenantCommandHandlerBase : CommandBase<CreateTenantCommand,TenantEntity>, IRequestHandler <CreateTenantCommand, TenantKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory;

	public CreateTenantCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> WorkplaceFactory,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.WorkplaceFactory = WorkplaceFactory;
	}

	public virtual async Task<TenantKeyDto> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
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
				var relatedEntity = WorkplaceFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToWorkplaces(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Tenants.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new TenantKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateTenantValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantValidator()
    {
		RuleFor(x => x.EntityDto.TenantBrands)
			.Must(owned => owned.All(x => x.Id == null))
			.WithMessage("TenantBrands.Id must be null as it is auto generated.");
    }
}