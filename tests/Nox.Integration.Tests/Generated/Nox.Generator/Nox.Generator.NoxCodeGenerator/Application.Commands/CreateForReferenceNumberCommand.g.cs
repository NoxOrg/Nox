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

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Commands;

public partial record CreateForReferenceNumberCommand(ForReferenceNumberCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ForReferenceNumberKeyDto>;

internal partial class CreateForReferenceNumberCommandHandler : CreateForReferenceNumberCommandHandlerBase
{
	public CreateForReferenceNumberCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateForReferenceNumberCommandHandlerBase : CommandBase<CreateForReferenceNumberCommand,ForReferenceNumberEntity>, IRequestHandler <CreateForReferenceNumberCommand, ForReferenceNumberKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> EntityFactory;

	protected CreateForReferenceNumberCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ForReferenceNumberKeyDto> Handle(CreateForReferenceNumberCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.ForReferenceNumbers.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ForReferenceNumberKeyDto(entityToCreate.Id.Value);
	}
}