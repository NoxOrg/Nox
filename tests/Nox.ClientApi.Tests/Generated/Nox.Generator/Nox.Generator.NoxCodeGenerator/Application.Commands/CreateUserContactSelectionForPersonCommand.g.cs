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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using UserContactSelectionEntity = ClientApi.Domain.UserContactSelection;

namespace ClientApi.Application.Commands;
public partial record CreateUserContactSelectionForPersonCommand(PersonKeyDto ParentKeyDto, UserContactSelectionUpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <UserContactSelectionKeyDto>;

internal partial class CreateUserContactSelectionForPersonCommandHandler : CreateUserContactSelectionForPersonCommandHandlerBase
{
	public CreateUserContactSelectionForPersonCommandHandler(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class CreateUserContactSelectionForPersonCommandHandlerBase : CommandBase<CreateUserContactSelectionForPersonCommand, UserContactSelectionEntity>, IRequestHandler<CreateUserContactSelectionForPersonCommand, UserContactSelectionKeyDto?>
{
	protected readonly Nox.Domain.IRepository Repository;
	protected readonly IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> RntityFactory;
	
	protected CreateUserContactSelectionForPersonCommandHandlerBase(
        Nox.Domain.IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<UserContactSelectionEntity, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		RntityFactory = entityFactory;
	}

	public virtual  async Task<UserContactSelectionKeyDto?> Handle(CreateUserContactSelectionForPersonCommand request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);
		var keyId = Dto.PersonMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await Repository.FindAsync<Person> (keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Person",  $"{keyId.ToString()}");
		}

		var entity = await RntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		parentEntity.CreateRefToUserContactSelection(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		Repository.SetStateModified(parentEntity);		
		await Repository.SaveChangesAsync();

		return new UserContactSelectionKeyDto();
	}
}