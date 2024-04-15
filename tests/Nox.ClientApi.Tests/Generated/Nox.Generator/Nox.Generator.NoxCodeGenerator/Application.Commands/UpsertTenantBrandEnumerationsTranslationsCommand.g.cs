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
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Commands;
public partial record UpsertTenantBrandsStatusesTranslationCommand(Enumeration Id, TenantBrandStatusLocalizedUpsertDto TenantBrandStatusLocalizedUpsertDto, CultureCode CultureCode) : IRequest<TenantBrandStatusLocalizedKeyDto>;

internal partial class UpsertTenantBrandsStatusesTranslationCommandHandler : UpsertTenantBrandsStatusesTranslationCommandHandlerBase
{
	public UpsertTenantBrandsStatusesTranslationCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class UpsertTenantBrandsStatusesTranslationCommandHandlerBase : CommandBase<UpsertTenantBrandsStatusesTranslationCommand, TenantBrandStatusLocalized>, IRequestHandler<UpsertTenantBrandsStatusesTranslationCommand, TenantBrandStatusLocalizedKeyDto>
{
	
	public IRepository Repository { get; }
	public UpsertTenantBrandsStatusesTranslationCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<TenantBrandStatusLocalizedKeyDto> Handle(UpsertTenantBrandsStatusesTranslationCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		
		var localizedEntity = await Repository.Query<TenantBrandStatusLocalized>()
			.Where(x =>x.Id == command.Id && x.CultureCode == command.CultureCode)			
			.FirstOrDefaultAsync(cancellationToken);
		
		if(localizedEntity is not null)
		{
			localizedEntity.Name = command.TenantBrandStatusLocalizedUpsertDto.Name;
		}
		else
		{
			localizedEntity = new TenantBrandStatusLocalized {Id = command.Id, CultureCode = command.CultureCode, Name = command.TenantBrandStatusLocalizedUpsertDto.Name};
			await Repository.AddAsync(localizedEntity, cancellationToken);
		}
		
		if(command.CultureCode == DefaultCultureCode)
		{
			var e = new TenantBrandStatus { Id = command.Id, Name = command.TenantBrandStatusLocalizedUpsertDto.Name };			
			Repository.Update(e);
		}
		
		

		await OnCompletedAsync(command, localizedEntity);
		await Repository.SaveChangesAsync(cancellationToken);
		return new TenantBrandStatusLocalizedKeyDto(command.Id.Value, command.CultureCode.Value);
	}
}
public class UpsertTenantBrandsStatusesTranslationCommandValidator : AbstractValidator<UpsertTenantBrandsStatusesTranslationCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1, 2, };
	
    public UpsertTenantBrandsStatusesTranslationCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertTenantBrandsStatusesTranslationCommand)} : {nameof(UpsertTenantBrandsStatusesTranslationCommand.CultureCode)}  not supported: {x.Value}.");
		
		RuleFor(x => x.Id)
			.Must(x => _supportedIds.Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertTenantBrandsStatusesTranslationCommand)} : {nameof(UpsertTenantBrandsStatusesTranslationCommand.Id)} not supported: {x.Value}.");
    }
}