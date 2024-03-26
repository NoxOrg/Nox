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


using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Commands;

public partial record UpdateCommissionCommand(System.Guid keyId, CommissionUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CommissionKeyDto>;

internal partial class UpdateCommissionCommandHandler : UpdateCommissionCommandHandlerBase
{
	public UpdateCommissionCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCommissionCommandHandlerBase : CommandBase<UpdateCommissionCommand, CommissionEntity>, IRequestHandler<UpdateCommissionCommand, CommissionKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> EntityFactory { get; }
	protected UpdateCommissionCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CommissionKeyDto> Handle(UpdateCommissionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<Cryptocash.Domain.Commission>()
            .Where(x => x.Id == Dto.CommissionMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Commission",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new CommissionKeyDto(entity.Id.Value);
	}
}