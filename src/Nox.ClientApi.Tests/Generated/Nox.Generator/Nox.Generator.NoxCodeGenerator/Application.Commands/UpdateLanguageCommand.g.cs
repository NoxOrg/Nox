﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using LanguageEntity = ClientApi.Domain.Language;

namespace ClientApi.Application.Commands;

public partial record UpdateLanguageCommand(System.String keyId, LanguageUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<LanguageKeyDto?>;

internal partial class UpdateLanguageCommandHandler : UpdateLanguageCommandHandlerBase
{
	public UpdateLanguageCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> entityFactory,
		IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution,entityFactory, entityLocalizedFactory)
	{
	}
}

internal abstract class UpdateLanguageCommandHandlerBase : CommandBase<UpdateLanguageCommand, LanguageEntity>, IRequestHandler<UpdateLanguageCommand, LanguageKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> _entityFactory;
	private readonly IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> _entityLocalizedFactory;

	protected UpdateLanguageCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> entityFactory,
		IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory; 
		_entityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<LanguageKeyDto?> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.LanguageMetadata.CreateId(request.keyId);

		var entity = await DbContext.Languages.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await UpdateLocalizationsAsync(entity, request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new LanguageKeyDto(entity.Id.Value);
	}

	private async Task UpdateLocalizationsAsync(LanguageEntity entity, LanguageUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		await UpdateLanguageLocalizationAsync(entity, updateDto, cultureCode);
	}

	private async Task UpdateLanguageLocalizationAsync(LanguageEntity entity, LanguageUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.LanguagesLocalized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.LanguagesLocalized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		_entityLocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}
}