// Generated

#nullable enable

using MediatR;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Exceptions;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;
public partial record  UpsertCountriesContinentsTranslationsCommand(IEnumerable<CountryContinentLocalizedDto> CountryContinentLocalizedDtos) : IRequest<CultureCode>;

internal partial class UpsertCountriesContinentsTranslationsCommandHandler : UpsertCountriesContinentsTranslationsCommandHandlerBase
{
	public UpsertCountriesContinentsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class UpsertCountriesContinentsTranslationsCommandHandlerBase : CommandBase<UpsertCountriesContinentsTranslationsCommand, CountryContinentLocalized>, IRequestHandler<UpsertCountriesContinentsTranslationsCommand, CultureCode>
{
	public AppDbContext DbContext { get; }

	public UpsertCountriesContinentsTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<CultureCode> Handle(UpsertCountriesContinentsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);

		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		if(command.CountryContinentLocalizedDtos == null || command.CountryContinentLocalizedDtos.Count() == 0)
		{
			throw new ArgumentNullException($"No {nameof(command.CountryContinentLocalizedDtos)} found.");
		}
		
		var cultureCode = command.CountryContinentLocalizedDtos.First().CultureCode;
		var supportedCultureCodes = NoxSolution.Application?.Localization?.SupportedCultures?.ToHashSet();
		var cultureCodeValue = Nox.Types.CultureCode.From(cultureCode);
		
		if (supportedCultureCodes == null || !supportedCultureCodes.Contains(cultureCode))
		{
			throw new CultureCodeNotSupportedException($"Culture code {cultureCode} not supported.");
		}
		
		if (!command.CountryContinentLocalizedDtos.All(x => x.CultureCode == cultureCode))
		{
			throw new CultureCodeMismatchException($"Culture code {cultureCode} does not match.");
		}
		
		var ids = command.CountryContinentLocalizedDtos.Select(dto=> Enumeration.From(dto.Id)).ToList();
		var query =
			from Enum in DbContext.CountriesContinents
			join localized in DbContext.CountriesContinentsLocalized
				on  new {Id = Enum.Id, Culture = cultureCodeValue}  equals new  {Id = localized.Id, Culture = localized.CultureCode} into localizedEnumsJoin
			from LocalizedEnum in localizedEnumsJoin.DefaultIfEmpty()
			select new { Enum.Id, LocalizedId = LocalizedEnum.Id };
		
		
		var queryResult = await query.AsNoTracking().ToListAsync(cancellationToken);
			
		if(!(queryResult.Count == ids.Count && queryResult.All(x=> ids.Contains(x.Id))))
		{
			throw new InvalidEnumIdsException($"Provided ids are invalid for {nameof(DbContext.CountriesContinents)}.");
		}
		
		var localizedEntities = 
			command.CountryContinentLocalizedDtos.Select(dto => new CountryContinentLocalized {Id = Enumeration.From(dto.Id), CultureCode = cultureCodeValue, Name = dto.Name}).ToList();

		if (queryResult.First().LocalizedId == null)
		{
			DbContext.CountriesContinentsLocalized.AddRange(localizedEntities);
		}
		else
		{
			localizedEntities.ForEach(e=> DbContext.Entry(e).State = EntityState.Modified);
		}

		if (NoxSolution.Application?.Localization?.DefaultCulture == cultureCode)
		{
			command.CountryContinentLocalizedDtos.ForEach(dto =>
			{
				var e = new CountryContinent { Id = Enumeration.From(dto.Id), Name = dto.Name };
				DbContext.Entry(e).State = EntityState.Modified;
			});
		}

		await OnBatchCompletedAsync(command, localizedEntities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return cultureCodeValue;
	}
}