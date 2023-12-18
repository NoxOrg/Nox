﻿// Generated

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
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using ReferenceNumberEntityEntity = ClientApi.Domain.ReferenceNumberEntity;

namespace ClientApi.Application.Commands;

public partial record CreateReferenceNumberEntityCommand(ReferenceNumberEntityCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ReferenceNumberEntityKeyDto>;

internal partial class CreateReferenceNumberEntityCommandHandler : CreateReferenceNumberEntityCommandHandlerBase
{
	public CreateReferenceNumberEntityCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateReferenceNumberEntityCommandHandlerBase : CommandBase<CreateReferenceNumberEntityCommand,ReferenceNumberEntityEntity>, IRequestHandler <CreateReferenceNumberEntityCommand, ReferenceNumberEntityKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> EntityFactory;

	protected CreateReferenceNumberEntityCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ReferenceNumberEntityKeyDto> Handle(CreateReferenceNumberEntityCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.ReferenceNumberEntities.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ReferenceNumberEntityKeyDto(entityToCreate.Id.Value);
	}
}