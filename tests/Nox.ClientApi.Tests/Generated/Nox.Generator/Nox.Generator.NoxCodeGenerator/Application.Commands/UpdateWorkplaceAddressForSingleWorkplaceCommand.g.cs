﻿﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceAddressEntity = ClientApi.Domain.WorkplaceAddress;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public partial record UpdateWorkplaceAddressForSingleWorkplaceCommand(WorkplaceKeyDto ParentKeyDto, WorkplaceAddressUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <WorkplaceAddressKeyDto>;

internal partial class UpdateWorkplaceAddressForSingleWorkplaceCommandHandler : UpdateWorkplaceAddressForSingleWorkplaceCommandHandlerBase
{
	public UpdateWorkplaceAddressForSingleWorkplaceCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateWorkplaceAddressForSingleWorkplaceCommandHandlerBase : CommandBase<UpdateWorkplaceAddressForSingleWorkplaceCommand, WorkplaceAddressEntity>, IRequestHandler <UpdateWorkplaceAddressForSingleWorkplaceCommand, WorkplaceAddressKeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> _entityFactory;

	protected UpdateWorkplaceAddressForSingleWorkplaceCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<WorkplaceAddressKeyDto> Handle(UpdateWorkplaceAddressForSingleWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Workplace>(keys.ToArray(),e => e.WorkplaceAddresses, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Workplace",  "keyId");
		var entity = parentEntity.WorkplaceAddresses.Find(e => e.Id == Dto.WorkplaceAddressMetadata.CreateId(request.EntityDto.Id!.Value )); 
		EntityNotFoundException.ThrowIfNull(entity, "WorkplaceAddress",  "keyId");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new WorkplaceAddressKeyDto(entity.Id.Value);
	}
}

public class UpdateWorkplaceAddressForSingleWorkplaceCommandValidator : AbstractValidator<UpdateWorkplaceAddressForSingleWorkplaceCommand>
{
    public UpdateWorkplaceAddressForSingleWorkplaceCommandValidator()
    { 
    }
}