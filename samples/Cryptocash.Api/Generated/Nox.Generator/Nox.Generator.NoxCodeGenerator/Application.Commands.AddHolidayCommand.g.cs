﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Holiday = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Commands;
public record AddHolidayCommand(CountryKeyDto ParentKeyDto, HolidayCreateDto EntityDto, System.Guid? Etag) : IRequest <HolidayKeyDto?>;

public partial class AddHolidayCommandHandler: CommandBase<AddHolidayCommand, Holiday>, IRequestHandler <AddHolidayCommand, HolidayKeyDto?>
{
	public CryptocashDbContext DbContext { get; }

	public AddHolidayCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;		
	}

	public async Task<HolidayKeyDto?> Handle(AddHolidayCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Country,CountryCode2>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Countries.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}

		var entity = request.EntityDto.ToEntity();
		
		parentEntity.Holidays.Add(entity);
		parentEntity.Etag = request.Etag.HasValue ? Nox.Types.Guid.From(request.Etag.Value) : Nox.Types.Guid.Empty;
		OnCompleted(entity);
	
		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new HolidayKeyDto(entity.Id.Value);
	}
}