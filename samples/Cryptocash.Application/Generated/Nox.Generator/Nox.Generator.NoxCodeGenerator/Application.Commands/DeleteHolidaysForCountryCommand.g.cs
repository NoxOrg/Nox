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
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using HolidayEntity = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Commands;
public partial record DeleteHolidaysForCountryCommand(CountryKeyDto ParentKeyDto, HolidayKeyDto EntityKeyDto, System.Guid? Etag) : IRequest <bool>;

internal partial class DeleteHolidaysForCountryCommandHandler : DeleteHolidaysForCountryCommandHandlerBase
{
	public DeleteHolidaysForCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteHolidaysForCountryCommandHandlerBase : CommandBase<DeleteHolidaysForCountryCommand, HolidayEntity>, IRequestHandler <DeleteHolidaysForCountryCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteHolidaysForCountryCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteHolidaysForCountryCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<Cryptocash.Domain.Country>(keys.ToArray(), p => p.Holidays, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Country",  "keyId");
		}
		var ownedId = Dto.HolidayMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.Holidays.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Holiday.Holidays",  $"ownedId");
		}
		parentEntity.DeleteHolidays(entity);
		
		parentEntity.Etag = request.Etag ?? System.Guid.Empty;
		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}