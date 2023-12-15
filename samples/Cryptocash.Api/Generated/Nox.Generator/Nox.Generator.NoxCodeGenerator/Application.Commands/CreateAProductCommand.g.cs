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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using AProductEntity = Cryptocash.Domain.AProduct;

namespace Cryptocash.Application.Commands;

public partial record CreateAProductCommand(AProductCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<AProductKeyDto>;

internal partial class CreateAProductCommandHandler : CreateAProductCommandHandlerBase
{
	public CreateAProductCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> entityFactory)
		: base(dbContext, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateAProductCommandHandlerBase : CommandBase<CreateAProductCommand,AProductEntity>, IRequestHandler <CreateAProductCommand, AProductKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> EntityFactory;

	protected CreateAProductCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<AProductEntity, AProductCreateDto, AProductUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<AProductKeyDto> Handle(CreateAProductCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.AProducts.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new AProductKeyDto(entityToCreate.Id.Value);
	}
}