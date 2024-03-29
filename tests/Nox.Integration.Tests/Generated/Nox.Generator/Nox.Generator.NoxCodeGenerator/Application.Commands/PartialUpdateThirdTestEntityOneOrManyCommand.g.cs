﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record PartialUpdateThirdTestEntityOneOrManyCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ThirdTestEntityOneOrManyKeyDto>;

internal partial class PartialUpdateThirdTestEntityOneOrManyCommandHandler : PartialUpdateThirdTestEntityOneOrManyCommandHandlerBase
{
	public PartialUpdateThirdTestEntityOneOrManyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(repository,noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateThirdTestEntityOneOrManyCommandHandlerBase : CommandBase<PartialUpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyEntity>, IRequestHandler<PartialUpdateThirdTestEntityOneOrManyCommand, ThirdTestEntityOneOrManyKeyDto>
{
	public IRepository Repository { get; }
	public IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> EntityFactory { get; }
	
	public PartialUpdateThirdTestEntityOneOrManyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ThirdTestEntityOneOrManyEntity, ThirdTestEntityOneOrManyCreateDto, ThirdTestEntityOneOrManyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ThirdTestEntityOneOrManyKeyDto> Handle(PartialUpdateThirdTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Dto.ThirdTestEntityOneOrManyMetadata.CreateId(request.keyId);

		var entity = await Repository.FindAsync<TestWebApp.Domain.ThirdTestEntityOneOrMany>(keyId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ThirdTestEntityOneOrMany",  $"{keyId.ToString()}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;		
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);

		await Repository.SaveChangesAsync();
		return new ThirdTestEntityOneOrManyKeyDto(entity.Id.Value);
	}
}