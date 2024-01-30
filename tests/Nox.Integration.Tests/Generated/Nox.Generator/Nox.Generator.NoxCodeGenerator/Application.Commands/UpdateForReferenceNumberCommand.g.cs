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


using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Commands;

public partial record UpdateForReferenceNumberCommand(System.String keyId, ForReferenceNumberUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ForReferenceNumberKeyDto>;

internal partial class UpdateForReferenceNumberCommandHandler : UpdateForReferenceNumberCommandHandlerBase
{
	public UpdateForReferenceNumberCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateForReferenceNumberCommandHandlerBase : CommandBase<UpdateForReferenceNumberCommand, ForReferenceNumberEntity>, IRequestHandler<UpdateForReferenceNumberCommand, ForReferenceNumberKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> EntityFactory { get; }
	protected UpdateForReferenceNumberCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ForReferenceNumberKeyDto> Handle(UpdateForReferenceNumberCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<ForReferenceNumber>()
            .Where(x => x.Id == Dto.ForReferenceNumberMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("ForReferenceNumber",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new ForReferenceNumberKeyDto(entity.Id.Value);
	}
}