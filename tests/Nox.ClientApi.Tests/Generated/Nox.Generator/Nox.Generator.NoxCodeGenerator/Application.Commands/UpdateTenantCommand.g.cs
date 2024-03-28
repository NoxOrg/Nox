﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using TenantEntity = ClientApi.Domain.Tenant;

namespace ClientApi.Application.Commands;

public partial record UpdateTenantCommand(System.UInt32 keyId, TenantUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TenantKeyDto>;

internal partial class UpdateTenantCommandHandler : UpdateTenantCommandHandlerBase
{
	public UpdateTenantCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateTenantCommandHandlerBase : CommandBase<UpdateTenantCommand, TenantEntity>, IRequestHandler<UpdateTenantCommand, TenantKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> EntityFactory { get; }
	protected UpdateTenantCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<TenantEntity, TenantCreateDto, TenantUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<TenantKeyDto> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<ClientApi.Domain.Tenant>()
            .Where(x => x.Id == Dto.TenantMetadata.CreateId(request.keyId))
			.Include(e => e.TenantBrands)
			.Include(e => e.TenantContact)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Tenant",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		Repository.Update(entity);
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new TenantKeyDto(entity.Id.Value);
	}
}

public class UpdateTenantValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantValidator()
    {
    }
}