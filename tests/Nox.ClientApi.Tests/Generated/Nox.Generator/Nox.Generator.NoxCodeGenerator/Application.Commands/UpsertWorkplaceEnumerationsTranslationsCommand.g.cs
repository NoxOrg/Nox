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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;
public partial record UpsertWorkplacesOwnershipsTranslationCommand(Enumeration Id, WorkplaceOwnershipLocalizedUpsertDto WorkplaceOwnershipLocalizedUpsertDto, CultureCode CultureCode) : IRequest<WorkplaceOwnershipLocalizedKeyDto>;

internal partial class UpsertWorkplacesOwnershipsTranslationCommandHandler : UpsertWorkplacesOwnershipsTranslationCommandHandlerBase
{
	public UpsertWorkplacesOwnershipsTranslationCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class UpsertWorkplacesOwnershipsTranslationCommandHandlerBase : CommandBase<UpsertWorkplacesOwnershipsTranslationCommand, WorkplaceOwnershipLocalized>, IRequestHandler<UpsertWorkplacesOwnershipsTranslationCommand, WorkplaceOwnershipLocalizedKeyDto>
{
	
	public IRepository Repository { get; }
	public UpsertWorkplacesOwnershipsTranslationCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<WorkplaceOwnershipLocalizedKeyDto> Handle(UpsertWorkplacesOwnershipsTranslationCommand command, CancellationToken cancellationToken)
	{
		System.Diagnostics.Debug.WriteLine("UpsertTranslationCommandHandle");
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		
		var localizedEntity = await Repository.Query<WorkplaceOwnershipLocalized>()
			.Where(x =>x.Id == command.Id && x.CultureCode == command.CultureCode)			
			.FirstOrDefaultAsync(cancellationToken);
		
		if(localizedEntity is not null)
		{
			localizedEntity.Name = command.WorkplaceOwnershipLocalizedUpsertDto.Name;
		}
		else
		{
			localizedEntity = new WorkplaceOwnershipLocalized {Id = command.Id, CultureCode = command.CultureCode, Name = command.WorkplaceOwnershipLocalizedUpsertDto.Name};
			await Repository.AddAsync(localizedEntity, cancellationToken);
		}
		
		if(command.CultureCode == DefaultCultureCode)
		{
			var e = new WorkplaceOwnership { Id = command.Id, Name = command.WorkplaceOwnershipLocalizedUpsertDto.Name };			
			Repository.Update(e);
		}
		
		

		await OnCompletedAsync(command, localizedEntity);
		await Repository.SaveChangesAsync(cancellationToken);
		return new WorkplaceOwnershipLocalizedKeyDto(command.Id.Value, command.CultureCode.Value);
	}
}
public class UpsertWorkplacesOwnershipsTranslationCommandValidator : AbstractValidator<UpsertWorkplacesOwnershipsTranslationCommand>
{
	private static readonly int[] _supportedIds = new int[] { 1000, 4000, 5000, };
	
    public UpsertWorkplacesOwnershipsTranslationCommandValidator(NoxSolution noxSolution)
    {
	    System.Diagnostics.Debug.WriteLine("UpsertTranslationCommandValidator");
		RuleFor(x => x.CultureCode)
			.Must(x => noxSolution!.Application!.Localization!.SupportedCultures.Select(c => c.ToDisplayName()).Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertWorkplacesOwnershipsTranslationCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationCommand.CultureCode)}  not supported: {x.Value}.");
		
		RuleFor(x => x.Id)
			.Must(x => _supportedIds.Contains(x.Value))
			.WithMessage((_,x) => $"{nameof(UpsertWorkplacesOwnershipsTranslationCommand)} : {nameof(UpsertWorkplacesOwnershipsTranslationCommand.Id)} not supported: {x.Value}.");
    }
}