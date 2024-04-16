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

public partial record DeleteAllCountryLocalNamesForCountryCommand(CountryKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllCountryLocalNamesForCountryCommandHandler : DeleteAllCountryLocalNamesForCountryCommandHandlerBase
{
	public DeleteAllCountryLocalNamesForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllCountryLocalNamesForCountryCommandHandlerBase : CommandCollectionBase<DeleteAllCountryLocalNamesForCountryCommand, CountryLocalNameEntity>, IRequestHandler <DeleteAllCountryLocalNamesForCountryCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllCountryLocalNamesForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));
		
		
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(), p => p.CountryLocalNames, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "parentKeyId");
		
		if(parentEntity.CountryLocalNames is not null)
		{
			Repository.DeleteOwned(parentEntity.CountryLocalNames!);
			await OnCompletedAsync(request, parentEntity.CountryLocalNames!);
		}
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}