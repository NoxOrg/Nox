﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public partial record DeleteCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteCountryLocalNamesForCountryCommandHandler : DeleteCountryLocalNamesForCountryCommandHandlerBase
{
	public DeleteCountryLocalNamesForCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteCountryLocalNamesForCountryCommandHandlerBase : CommandBase<DeleteCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler <DeleteCountryLocalNamesForCountryCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCountryLocalNamesForCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.CountryMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(parentEntity).Collection(p => p.CountryLocalNames).LoadAsync(cancellationToken);
		var ownedId = ClientApi.Domain.CountryLocalNameMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryLocalName.CountryLocalNames",  $"{ownedId.ToString()}");
		}
		parentEntity.CountryLocalNames.Remove(entity);
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return true;
	}
}