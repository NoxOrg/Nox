﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Commands;

public partial record CreateForReferenceNumberCommand(ForReferenceNumberCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ForReferenceNumberKeyDto>;

internal partial class CreateForReferenceNumberCommandHandler : CreateForReferenceNumberCommandHandlerBase
{
	public CreateForReferenceNumberCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
		: base(repository, noxSolution,entityFactory)
	{
	}
}


internal abstract class CreateForReferenceNumberCommandHandlerBase : CommandBase<CreateForReferenceNumberCommand,ForReferenceNumberEntity>, IRequestHandler <CreateForReferenceNumberCommand, ForReferenceNumberKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> EntityFactory;

	protected CreateForReferenceNumberCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ForReferenceNumberKeyDto> Handle(CreateForReferenceNumberCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<TestWebApp.Domain.ForReferenceNumber>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new ForReferenceNumberKeyDto(entityToCreate.Id.Value);
	}
}