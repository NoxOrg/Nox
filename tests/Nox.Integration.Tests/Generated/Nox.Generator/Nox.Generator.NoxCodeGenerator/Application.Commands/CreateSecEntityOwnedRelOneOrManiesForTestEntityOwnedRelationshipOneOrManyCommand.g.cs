﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;

using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using SecEntityOwnedRelOneOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelOneOrMany;

namespace TestWebApp.Application.Commands;
public partial record CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecEntityOwnedRelOneOrManyUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <SecEntityOwnedRelOneOrManyKeyDto>;

internal partial class CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler : CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyEntity>, IRequestHandler<CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> RntityFactory;
	
	protected CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<SecEntityOwnedRelOneOrManyEntity, SecEntityOwnedRelOneOrManyUpsertDto, SecEntityOwnedRelOneOrManyUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<SecEntityOwnedRelOneOrManyKeyDto?> Handle(CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipOneOrMany",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateSecEntityOwnedRelOneOrManies(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);		
		await Repository.SaveChangesAsync();

		return new SecEntityOwnedRelOneOrManyKeyDto(entity.Id.Value);
	}
}

public class CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator : AbstractValidator<CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand>
{
    public CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyValidator()
    {
		RuleFor(x => x.EntityDto.Id).NotNull().WithMessage("Id is required.");
    }
}