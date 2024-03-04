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
public partial record UpsertCountriesContinentsTranslationCommand(Enumeration Id, CountryContinentLocalizedUpsertDto CountryContinentLocalizedUpsertDto, CultureCode CultureCode) : IRequest<CountryContinentLocalizedKeyDto>;

internal partial class UpsertCountriesContinentsTranslationCommandHandler : UpsertCountriesContinentsTranslationCommandHandlerBase
{
	public UpsertCountriesContinentsTranslationCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class UpsertCountriesContinentsTranslationCommandHandlerBase : CommandBase<UpsertCountriesContinentsTranslationCommand, CountryContinentLocalized>, IRequestHandler<UpsertCountriesContinentsTranslationCommand, CountryContinentLocalizedKeyDto>
{
	
	public IRepository Repository { get; }
	public UpsertCountriesContinentsTranslationCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<CountryContinentLocalizedKeyDto> Handle(UpsertCountriesContinentsTranslationCommand command, CancellationToken cancellationToken)
	{
		System.Diagnostics.Debug.WriteLine("UpsertTranslationCommandHandle");
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		
		var localizedEntity = await Repository.Query<CountryContinentLocalized>()
			.Where(x =>x.Id == command.Id && x.CultureCode == command.CultureCode)			
			.FirstOrDefaultAsync(cancellationToken);
		
		if(localizedEntity is not null)
		{
			localizedEntity.Name = command.CountryContinentLocalizedUpsertDto.Name;
		}
		else
		{
			localizedEntity = new CountryContinentLocalized {Id = command.Id, CultureCode = command.CultureCode, Name = command.CountryContinentLocalizedUpsertDto.Name};
			await Repository.AddAsync(localizedEntity, cancellationToken);
		}
		
		if(command.CultureCode == DefaultCultureCode)
		{
			var e = new CountryContinent { Id = command.Id, Name = command.CountryContinentLocalizedUpsertDto.Name };			
			Repository.Update(e);
		}
		
		

		await OnCompletedAsync(command, localizedEntity);
		await Repository.SaveChangesAsync(cancellationToken);
		return new CountryContinentLocalizedKeyDto(command.Id.Value, command.CultureCode.Value);
	}
}
public class UpsertCountriesContinentsTranslationCommandValidator : AbstractValidator<UpsertCountriesContinentsTranslationCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1, 2, 3, 4, 5, };
	
    public UpsertCountriesContinentsTranslationCommandValidator(NoxSolution noxSolution)
    {
	    System.Diagnostics.Debug.WriteLine("UpsertTranslationCommandValidator");
		RuleFor(x => x.CultureCode)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertCountriesContinentsTranslationCommand)} : {nameof(UpsertCountriesContinentsTranslationCommand.CultureCode)}  not supported: {x.Value}.");
		
		RuleFor(x => x.Id)
			.Must(x => _supportedIds.Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertCountriesContinentsTranslationCommand)} : {nameof(UpsertCountriesContinentsTranslationCommand.Id)} not supported: {x.Value}.");
    }
}