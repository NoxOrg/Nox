﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public record DeleteCountryLocalNameForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteCountryLocalNameForCountryCommandHandler : DeleteCountryLocalNameForCountryCommandHandlerBase
{
	public DeleteCountryLocalNameForCountryCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteCountryLocalNameForCountryCommandHandlerBase : CommandBase<DeleteCountryLocalNameForCountryCommand, CountryLocalNameEntity>, IRequestHandler <DeleteCountryLocalNameForCountryCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteCountryLocalNameForCountryCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryLocalNameForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = ClientApi.Domain.CountryLocalNameMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryShortNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.CountryShortNames.Remove(entity);
		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}