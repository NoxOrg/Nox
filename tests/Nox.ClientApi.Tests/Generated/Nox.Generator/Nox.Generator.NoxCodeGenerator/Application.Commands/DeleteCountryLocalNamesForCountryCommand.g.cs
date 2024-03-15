﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Commands;
public partial record DeleteCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, CountryLocalNameKeyDto EntityKeyDto, System.Guid? Etag) : IRequest <bool>;

internal partial class DeleteCountryLocalNamesForCountryCommandHandler : DeleteCountryLocalNamesForCountryCommandHandlerBase
{
	public DeleteCountryLocalNamesForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteCountryLocalNamesForCountryCommandHandlerBase : CommandBase<DeleteCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler <DeleteCountryLocalNamesForCountryCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteCountryLocalNamesForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Country, ClientApi.Domain.CountryLocalName, ClientApi.Domain.CountryLocalNameLocalized>(keys.ToArray(), p => p.CountryLocalNames, p => p.LocalizedCountryLocalNames, cancellationToken);
				if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  "keyId");
		}
		var ownedId = Dto.CountryLocalNameMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CountryLocalNames.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("CountryLocalName.CountryLocalNames",  $"ownedId");
		}
		parentEntity.DeleteCountryLocalNames(entity);
		
		parentEntity.Etag = request.Etag ?? System.Guid.Empty;
		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}