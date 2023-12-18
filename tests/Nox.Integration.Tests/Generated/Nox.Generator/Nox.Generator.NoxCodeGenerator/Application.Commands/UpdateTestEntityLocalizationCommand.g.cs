﻿﻿
// Generated

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
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Commands;

public partial record UpdateTestEntityLocalizationCommand(System.String keyId, TestEntityLocalizationUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<TestEntityLocalizationKeyDto>;

internal partial class UpdateTestEntityLocalizationCommandHandler : UpdateTestEntityLocalizationCommandHandlerBase
{
	public UpdateTestEntityLocalizationCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory,
		IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution,entityFactory, entityLocalizedFactory)
	{
	}
}

internal abstract class UpdateTestEntityLocalizationCommandHandlerBase : CommandBase<UpdateTestEntityLocalizationCommand, TestEntityLocalizationEntity>, IRequestHandler<UpdateTestEntityLocalizationCommand, TestEntityLocalizationKeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> _entityFactory;
	private readonly IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> _entityLocalizedFactory;

	protected UpdateTestEntityLocalizationCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto> entityFactory,
		IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory; 
		_entityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<TestEntityLocalizationKeyDto> Handle(UpdateTestEntityLocalizationCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateId(request.keyId);

		var entity = await DbContext.TestEntityLocalizations.FindAsync(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityLocalization",  $"{keyId.ToString()}");
		}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await UpdateLocalizationsAsync(entity, request.EntityDto, request.CultureCode);

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new TestEntityLocalizationKeyDto(entity.Id.Value);
	}

	private async Task UpdateLocalizationsAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.TestEntityLocalizationsLocalized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = await _entityLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode);
			DbContext.TestEntityLocalizationsLocalized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		await _entityLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
	}
}