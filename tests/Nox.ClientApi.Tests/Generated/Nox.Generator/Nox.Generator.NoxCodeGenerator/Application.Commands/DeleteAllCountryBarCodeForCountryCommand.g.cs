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
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Commands;

public partial record DeleteAllCountryBarCodeForCountryCommand(CountryKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllCountryBarCodeForCountryCommandHandler : DeleteAllCountryBarCodeForCountryCommandHandlerBase
{
	public DeleteAllCountryBarCodeForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllCountryBarCodeForCountryCommandHandlerBase : CommandBase<DeleteAllCountryBarCodeForCountryCommand, CountryBarCodeEntity>, IRequestHandler <DeleteAllCountryBarCodeForCountryCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllCountryBarCodeForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllCountryBarCodeForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));
		
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(), p => p.CountryBarCode, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "parentKeyId");
		
		if(parentEntity.CountryBarCode is not null)
		{
			Repository.DeleteOwned(parentEntity.CountryBarCode!);
			await OnCompletedAsync(request, parentEntity.CountryBarCode!);
		}
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}