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
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Commands;
public partial record UpsertTenantContactsStatusesTranslationCommand(Enumeration Id, TenantContactStatusLocalizedUpsertDto TenantContactStatusLocalizedUpsertDto, CultureCode CultureCode) : IRequest<TenantContactStatusLocalizedKeyDto>;

internal partial class UpsertTenantContactsStatusesTranslationCommandHandler : UpsertTenantContactsStatusesTranslationCommandHandlerBase
{
	public UpsertTenantContactsStatusesTranslationCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class UpsertTenantContactsStatusesTranslationCommandHandlerBase : CommandBase<UpsertTenantContactsStatusesTranslationCommand, TenantContactStatusLocalized>, IRequestHandler<UpsertTenantContactsStatusesTranslationCommand, TenantContactStatusLocalizedKeyDto>
{
	
	public IRepository Repository { get; }
	public UpsertTenantContactsStatusesTranslationCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<TenantContactStatusLocalizedKeyDto> Handle(UpsertTenantContactsStatusesTranslationCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		
		var localizedEntity = await Repository.Query<TenantContactStatusLocalized>()
			.Where(x =>x.Id == command.Id && x.CultureCode == command.CultureCode)			
			.FirstOrDefaultAsync(cancellationToken);
		
		if(localizedEntity is not null)
		{
			localizedEntity.Name = command.TenantContactStatusLocalizedUpsertDto.Name;
		}
		else
		{
			localizedEntity = new TenantContactStatusLocalized {Id = command.Id, CultureCode = command.CultureCode, Name = command.TenantContactStatusLocalizedUpsertDto.Name};
			await Repository.AddAsync(localizedEntity, cancellationToken);
		}
		
		if(command.CultureCode == DefaultCultureCode)
		{
			var e = new TenantContactStatus { Id = command.Id, Name = command.TenantContactStatusLocalizedUpsertDto.Name };			
			Repository.Update(e);
		}
		
		

		await OnCompletedAsync(command, localizedEntity);
		await Repository.SaveChangesAsync(cancellationToken);
		return new TenantContactStatusLocalizedKeyDto(command.Id.Value, command.CultureCode.Value);
	}
}
public class UpsertTenantContactsStatusesTranslationCommandValidator : AbstractValidator<UpsertTenantContactsStatusesTranslationCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1, 2, };
	
    public UpsertTenantContactsStatusesTranslationCommandValidator(NoxSolution noxSolution)
    {
		RuleFor(x => x.CultureCode)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertTenantContactsStatusesTranslationCommand)} : {nameof(UpsertTenantContactsStatusesTranslationCommand.CultureCode)}  not supported: {x.Value}.");
		
		RuleFor(x => x.Id)
			.Must(x => _supportedIds.Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertTenantContactsStatusesTranslationCommand)} : {nameof(UpsertTenantContactsStatusesTranslationCommand.Id)} not supported: {x.Value}.");
    }
}