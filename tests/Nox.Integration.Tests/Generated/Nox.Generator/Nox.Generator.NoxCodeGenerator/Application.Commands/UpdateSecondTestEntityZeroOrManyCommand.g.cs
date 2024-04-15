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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateSecondTestEntityZeroOrManyCommand(System.String keyId, SecondTestEntityZeroOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<SecondTestEntityZeroOrManyKeyDto>;

internal partial class UpdateSecondTestEntityZeroOrManyCommandHandler : UpdateSecondTestEntityZeroOrManyCommandHandlerBase
{
	public UpdateSecondTestEntityZeroOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateSecondTestEntityZeroOrManyCommandHandlerBase : CommandBase<UpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyEntity>, IRequestHandler<UpdateSecondTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> EntityFactory { get; }
	protected UpdateSecondTestEntityZeroOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecondTestEntityZeroOrManyEntity, SecondTestEntityZeroOrManyCreateDto, SecondTestEntityZeroOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<SecondTestEntityZeroOrManyKeyDto> Handle(UpdateSecondTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.SecondTestEntityZeroOrMany>()
            .Where(x => x.Id == Dto.SecondTestEntityZeroOrManyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("SecondTestEntityZeroOrMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag ?? System.Guid.Empty;
		Repository.Update(entity);
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new SecondTestEntityZeroOrManyKeyDto(entity.Id.Value);
	}
}