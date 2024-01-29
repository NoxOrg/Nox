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
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public partial record UpdateStoreLicenseCommand(System.Int64 keyId, StoreLicenseUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<StoreLicenseKeyDto>;

internal partial class UpdateStoreLicenseCommandHandler : UpdateStoreLicenseCommandHandlerBase
{
	public UpdateStoreLicenseCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateStoreLicenseCommandHandlerBase : CommandBase<UpdateStoreLicenseCommand, StoreLicenseEntity>, IRequestHandler<UpdateStoreLicenseCommand, StoreLicenseKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> EntityFactory { get; }
	protected UpdateStoreLicenseCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreLicenseKeyDto> Handle(UpdateStoreLicenseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<StoreLicense>()
            .Where(x => x.Id == Dto.StoreLicenseMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		//Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new StoreLicenseKeyDto(entity.Id.Value);
	}
}