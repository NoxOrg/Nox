// Generated

#nullable enable

using MediatR;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Types.Abstractions.Extensions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;
public partial record  UpsertCountriesContinentsTranslationsCommand(IEnumerable<CountryContinentLocalizedDto> CountryContinentLocalizedDtos) : IRequest<IEnumerable<CountryContinentLocalizedDto>>;

internal partial class UpsertCountriesContinentsTranslationsCommandHandler : UpsertCountriesContinentsTranslationsCommandHandlerBase
{
	public UpsertCountriesContinentsTranslationsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class UpsertCountriesContinentsTranslationsCommandHandlerBase : CommandCollectionBase<UpsertCountriesContinentsTranslationsCommand, CountryContinentLocalized>, IRequestHandler<UpsertCountriesContinentsTranslationsCommand, IEnumerable<CountryContinentLocalizedDto>>
{
	public IRepository Repository { get; }
	public UpsertCountriesContinentsTranslationsCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<IEnumerable<CountryContinentLocalizedDto>> Handle(UpsertCountriesContinentsTranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		var cultureCodes = command.CountryContinentLocalizedDtos.DistinctBy(d=>d.CultureCode).Select(d=>CultureCode.From(d.CultureCode)).ToList();
		var localizedEntities = await Repository.Query<CountryContinentLocalized>()
			.Where(x => cultureCodes.Contains(x.CultureCode))			
			.ToListAsync(cancellationToken);
		
		var entities = new List<CountryContinentLocalized>();
		foreach(var dto in command.CountryContinentLocalizedDtos)
		{
            var entity = localizedEntities.SingleOrDefault(e=>e.Id == Enumeration.FromDatabase(dto.Id) && e.CultureCode == CultureCode.From(dto.CultureCode));
	        if(entity is not null)
			{
                entity.Name = dto.Name;
                entities.Add(entity);
            }
			else
			{
				var e = new CountryContinentLocalized {Id = Enumeration.FromDatabase(dto.Id), CultureCode = CultureCode.From(dto.CultureCode), Name = dto.Name};
				await Repository.AddAsync(e, cancellationToken);
				entities.Add(e);
			}
        }
		
		//Update Default in Entity 
		command.CountryContinentLocalizedDtos.Where(dto=>dto.CultureCode == DefaultCultureCode.Value).ForEach(dto =>
		{
			var e = new CountryContinent { Id = Enumeration.FromDatabase(dto.Id), Name = dto.Name };			
			Repository.Update(e);
		});
		

		await OnCompletedAsync(command, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return command.CountryContinentLocalizedDtos;
	}
}
public class UpsertCountriesContinentsTranslationsCommandValidator : AbstractValidator<UpsertCountriesContinentsTranslationsCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1, 2, 3, 4, 5, };
	
    public UpsertCountriesContinentsTranslationsCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CountryContinentLocalizedDtos)
			.Must(x => x != null && x.Count() > 0)
			.WithMessage($"{nameof(UpsertCountriesContinentsTranslationsCommand)} : {nameof(UpsertCountriesContinentsTranslationsCommand.CountryContinentLocalizedDtos)} is required.");
		
		RuleForEach(x => x.CountryContinentLocalizedDtos)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.CultureCode))
			.WithMessage((_,x) => $"{nameof(UpsertCountriesContinentsTranslationsCommand)} : {nameof(UpsertCountriesContinentsTranslationsCommand.CountryContinentLocalizedDtos)} contains unsupported culture code: {x.CultureCode}.");
		
		RuleForEach(x => x.CountryContinentLocalizedDtos)
			.Must(x => _supportedIds.Contains(x.Id))
			.WithMessage((_,x) => $"{nameof(UpsertCountriesContinentsTranslationsCommand)} : {nameof(UpsertCountriesContinentsTranslationsCommand.CountryContinentLocalizedDtos)} contains unsupported Id: {x.Id}.");
    }
}