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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record UpdateThirdTestEntityOneOrManyCommand(System.String keyId, ThirdTestEntityOneOrManyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<ThirdTestEntityOneOrManyKeyDto>;

internal partial class UpdateThirdTestEntityOneOrManyCommandHandler : UpdateThirdTestEntityOneOrManyCommandHandlerBase
{
	public UpdateThirdTestEntityOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateThirdTestEntityOneOrManyCommandHandlerBase : CommandBase<UpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyEntity>, IRequestHandler<UpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyKeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> EntityFactory { get; }
	protected UpdateThirdTestEntityOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityOneOrManyKeyDto> Handle(UpdateThirdTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<TestWebApp.Domain.ThirdTestEntityOneOrMany>()
            .Where(x => x.Id == Dto.ThirdTestEntityOneOrManyMetadata.CreateId(request.keyId))
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  "keyId");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new ThirdTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}