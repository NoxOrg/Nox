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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record UpdateStoreCommand(System.Guid keyId, StoreUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<StoreKeyDto>;

internal partial class UpdateStoreCommandHandler : UpdateStoreCommandHandlerBase
{
	public UpdateStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateStoreCommandHandlerBase : CommandBase<UpdateStoreCommand, StoreEntity>, IRequestHandler<UpdateStoreCommand, StoreKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> EntityFactory { get; }
	protected UpdateStoreCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreKeyDto> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<ClientApi.Domain.Store>()
            .Where(x => x.Id == Dto.StoreMetadata.CreateId(request.keyId))
			.Include(e => e.EmailAddress)
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new StoreKeyDto(entity.Id.Value);
	}
}

public class UpdateStoreValidator : AbstractValidator<UpdateStoreCommand>
{
    public UpdateStoreValidator()
    {
    }
}