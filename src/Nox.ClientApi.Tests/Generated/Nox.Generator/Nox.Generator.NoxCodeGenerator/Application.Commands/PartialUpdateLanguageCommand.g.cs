﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using LanguageEntity = ClientApi.Domain.Language;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateLanguageCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <LanguageKeyDto?>;

internal class PartialUpdateLanguageCommandHandler : PartialUpdateLanguageCommandHandlerBase
{
	public PartialUpdateLanguageCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> entityFactory,
		IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> entityLocalizedFactory)
		: base(dbContext,noxSolution, entityFactory, entityLocalizedFactory)
	{
	}
}
internal class PartialUpdateLanguageCommandHandlerBase : CommandBase<PartialUpdateLanguageCommand, LanguageEntity>, IRequestHandler<PartialUpdateLanguageCommand, LanguageKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto> EntityFactory { get; }
	public IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto> EntityLocalizedFactory { get; }

	public PartialUpdateLanguageCommandHandlerBase(
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

	public virtual async Task<LanguageKeyDto?> Handle(PartialUpdateLanguageCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.LanguageMetadata.CreateId(request.keyId);

		var entity = await DbContext.Languages.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await PartiallyUpdateLocalizedEntityAsync(entity, request.UpdatedProperties, request.CultureCode);

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new LanguageKeyDto(entity.Id.Value);
	}

	private async Task PartiallyUpdateLocalizedEntityAsync(LanguageEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.LanguagesLocalized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = EntityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode, copyEntityAttributes: false);
			DbContext.LanguagesLocalized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		EntityLocalizedFactory.PartialUpdateLocalizedEntity(entityLocalized, updatedProperties);
	}
}