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

public partial record DeleteAllHolidaysForCountryCommand(CountryKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllHolidaysForCountryCommandHandler : DeleteAllHolidaysForCountryCommandHandlerBase
{
	public DeleteAllHolidaysForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllHolidaysForCountryCommandHandlerBase : CommandBase<DeleteAllHolidaysForCountryCommand, CountryEntity>, IRequestHandler <DeleteAllHolidaysForCountryCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllHolidaysForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllHolidaysForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(), p => p.Holidays, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Country", "parentKeyId");
		
		Repository.DeleteOwned(parentEntity.Holidays);
		
		parentEntity.DeleteAllRefToHolidays();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, parentEntity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}