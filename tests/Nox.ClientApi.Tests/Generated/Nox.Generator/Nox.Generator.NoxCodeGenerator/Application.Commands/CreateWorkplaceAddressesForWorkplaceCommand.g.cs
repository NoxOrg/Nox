﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;

using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceAddressEntity = ClientApi.Domain.WorkplaceAddress;

namespace ClientApi.Application.Commands;
public partial record CreateWorkplaceAddressesForWorkplaceCommand(WorkplaceKeyDto ParentKeyDto, WorkplaceAddressUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <WorkplaceAddressKeyDto>;

internal partial class CreateWorkplaceAddressesForWorkplaceCommandHandler : CreateWorkplaceAddressesForWorkplaceCommandHandlerBase
{
	public CreateWorkplaceAddressesForWorkplaceCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateWorkplaceAddressesForWorkplaceCommandHandlerBase : CommandBase<CreateWorkplaceAddressesForWorkplaceCommand, WorkplaceAddressEntity>, IRequestHandler<CreateWorkplaceAddressesForWorkplaceCommand, WorkplaceAddressKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> RntityFactory;
	
	protected CreateWorkplaceAddressesForWorkplaceCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<WorkplaceAddressKeyDto?> Handle(CreateWorkplaceAddressesForWorkplaceCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.WorkplaceMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<ClientApi.Domain.Workplace> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Workplace",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateWorkplaceAddresses(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);		
		await Repository.SaveChangesAsync();

		return new WorkplaceAddressKeyDto(entity.Id.Value);
	}
}

public class CreateWorkplaceAddressesForWorkplaceValidator : AbstractValidator<CreateWorkplaceAddressesForWorkplaceCommand>
{
    public CreateWorkplaceAddressesForWorkplaceValidator()
    { 
    }
}