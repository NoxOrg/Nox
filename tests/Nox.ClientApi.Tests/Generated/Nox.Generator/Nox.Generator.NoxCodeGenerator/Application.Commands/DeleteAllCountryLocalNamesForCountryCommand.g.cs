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
using CountryEntity = ClientApi.Domain.Country;

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

internal partial class DeleteAllCountryLocalNamesForCountryCommandHandlerBase : CommandBase<DeleteAllCountryLocalNamesForCountryCommand, CountryEntity>, IRequestHandler <DeleteAllCountryLocalNamesForCountryCommand, bool>
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
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Country, ClientApi.Domain.CountryLocalName, ClientApi.Domain.CountryLocalNameLocalized>(
			keys.ToArray(), 
			p => p.CountryLocalNames, 
			l => l.LocalizedCountryLocalNames, 
			cancellationToken);
		
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "parentKeyId");
		
		Repository.DeleteOwned(parentEntity.CountryLocalNames);
		
		parentEntity.DeleteAllRefToCountryLocalNames();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, parentEntity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}