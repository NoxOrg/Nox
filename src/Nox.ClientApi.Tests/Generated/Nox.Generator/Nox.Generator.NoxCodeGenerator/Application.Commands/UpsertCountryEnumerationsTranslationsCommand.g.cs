// Generated

#nullable enable

using MediatR;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;
public partial record  UpsertCountriesContinentsTranslationsCommand(IEnumerable<CountryContinentLocalizedDto> CountryContinentLocalizedDtos) : IRequest<IEnumerable<CountryContinentLocalizedDto>>;

internal partial class UpsertCountriesContinentsTranslationsCommandHandler : UpsertCountriesContinentsTranslationsCommandHandlerBase
{
	public UpsertCountriesContinentsTranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class UpsertCountriesContinentsTranslationsCommandHandlerBase : CommandCollectionBase<UpsertCountriesContinentsTranslationsCommand, CountryContinentLocalized>, IRequestHandler<UpsertCountriesContinentsTranslationsCommand, IEnumerable<CountryContinentLocalizedDto>>
{
	public AppDbContext DbContext { get; }
	public UpsertCountriesContinentsTranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<IEnumerable<CountryContinentLocalizedDto>> Handle(UpsertCountriesContinentsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var cultureCodes = command.CountryContinentLocalizedDtos.DistinctBy(d=>d.CultureCode).Select(d=>CultureCode.From(d.CultureCode)).ToList();
		
		var localizedEntities = await DbContext.CountriesContinentsLocalized.Where(x => cultureCodes.Contains(x.CultureCode)).AsNoTracking().ToListAsync(cancellationToken);
		
		var entities = new List<CountryContinentLocalized>();
		
		command.CountryContinentLocalizedDtos.Where(dto=> !localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new CountryContinentLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Added;
			entities.Add(e);
		});
		
		command.CountryContinentLocalizedDtos.Where(dto=> localizedEntities.Any(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode))).ForEach(dto =>
		{
			var e = new CountryContinentLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
			DbContext.Entry(e).State = EntityState.Modified;
			entities.Add(e);
		});
		
		command.CountryContinentLocalizedDtos.Where(dto=>dto.CultureCode == DefaultCultureCode.Value).ForEach(dto =>
		{
			var e = new CountryContinent { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };
			DbContext.Entry(e).State = EntityState.Modified;
		});
		

		await OnCompletedAsync(command, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return command.CountryContinentLocalizedDtos;
	}
}
public class UpsertCountriesContinentsTranslationsCommandValidator : AbstractValidator<UpsertCountriesContinentsTranslationsCommand>
{
	private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
	private static readonly Nox.Types.CultureCode[] _supportedCultureCodes = new Nox.Types.CultureCode[] { Nox.Types.CultureCode.From("it-IT"), Nox.Types.CultureCode.From("fr-FR"), Nox.Types.CultureCode.From("en-US"), Nox.Types.CultureCode.From("de-DE"), };
	private static readonly int[] _supportedIds = new int[] { 1, 2, 3, 4, 5, };
	
    public UpsertCountriesContinentsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CountryContinentLocalizedDtos)
			.Must(x => x != null && x.Count() > 0)
			.WithMessage($"{nameof(UpsertCountriesContinentsTranslationsCommand)} : {nameof(UpsertCountriesContinentsTranslationsCommand.CountryContinentLocalizedDtos)} is required.");
		
		RuleForEach(x => x.CountryContinentLocalizedDtos)
			.Must(x => _supportedCultureCodes.Contains(x.CultureCode))
			.WithMessage((_,x) => $"{nameof(UpsertCountriesContinentsTranslationsCommand)} : {nameof(UpsertCountriesContinentsTranslationsCommand.CountryContinentLocalizedDtos)} contains unsupported culture code: {x.CultureCode}.");
		
		RuleForEach(x => x.CountryContinentLocalizedDtos)
			.Must(x => _supportedIds.Contains(x.Id))
			.WithMessage((_,x) => $"{nameof(UpsertCountriesContinentsTranslationsCommand)} : {nameof(UpsertCountriesContinentsTranslationsCommand.CountryContinentLocalizedDtos)} contains unsupported Id: {x.Id}.");
    }
}