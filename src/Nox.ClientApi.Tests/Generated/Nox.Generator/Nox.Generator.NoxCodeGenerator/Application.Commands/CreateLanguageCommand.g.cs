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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using LanguageEntity = ClientApi.Domain.Language;

namespace ClientApi.Application.Commands;

public partial record CreateLanguageCommand(LanguageCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<LanguageKeyDto>;

internal partial class CreateLanguageCommandHandler : CreateLanguageCommandHandlerBase
{
	public CreateLanguageCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> entityFactory,
		IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution,entityFactory, entityLocalizedFactory)
	{
	}
}


internal abstract class CreateLanguageCommandHandlerBase : CommandBase<CreateLanguageCommand,LanguageEntity>, IRequestHandler <CreateLanguageCommand, LanguageKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> EntityFactory;
	protected readonly IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> EntityLocalizedFactory;

	protected CreateLanguageCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> entityFactory,
		IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory; 
		EntityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<LanguageKeyDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Languages.Add(entityToCreate);
        CreateLocalizations(entityToCreate, request.CultureCode);
		await DbContext.SaveChangesAsync();
		return new LanguageKeyDto(entityToCreate.Id.Value);
	}

	private void CreateLocalizations(LanguageEntity entity, Nox.Types.CultureCode cultureCode)
	{
		CreateLanguageLocalization(entity, cultureCode);
	}

	private void CreateLanguageLocalization(LanguageEntity entity, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = EntityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
		DbContext.LanguagesLocalized.Add(entityLocalized);
	}
}