// Generated

#nullable enable
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;
using Nox.Extensions;

using ClientApi.Domain;
using WorkplaceAddressLocalizedEntity = ClientApi.Domain.WorkplaceAddressLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteWorkplaceAddressesTranslationsForWorkplaceCommand(System.Int64 keyId, System.Guid relatedKeyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteWorkplaceAddressesTranslationsForWorkplaceCommandHandler : DeleteWorkplaceAddressesTranslationsForWorkplaceCommandHandlerBase
{
    public DeleteWorkplaceAddressesTranslationsForWorkplaceCommandHandler(
        IRepository repository,
        NoxSolution noxSolution)
        : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteWorkplaceAddressesTranslationsForWorkplaceCommandHandlerBase : CommandBase<DeleteWorkplaceAddressesTranslationsForWorkplaceCommand, WorkplaceAddressLocalizedEntity>, IRequestHandler<DeleteWorkplaceAddressesTranslationsForWorkplaceCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteWorkplaceAddressesTranslationsForWorkplaceCommandHandlerBase(
        IRepository repository,
        NoxSolution noxSolution) 
        : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteWorkplaceAddressesTranslationsForWorkplaceCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
        
        var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(command.keyId));

        var parentEntity = await Repository.FindAsync<ClientApi.Domain.Workplace>(keys.ToArray(), cancellationToken);
        EntityNotFoundException.ThrowIfNull(parentEntity, "Workplace", "parentKeyId");

        var entity = await Repository.Query<ClientApi.Domain.WorkplaceAddressLocalized>().SingleOrDefaultAsync(x => x.Id == Dto.WorkplaceAddressMetadata.CreateId(command.relatedKeyId) && x.CultureCode == command.CultureCode, cancellationToken);
                EntityLocalizationNotFoundException.ThrowIfNull(entity, "Workplace.WorkplaceAddresses", "entityKeyId", command.CultureCode.ToString());
        
        Repository.Delete(entity);
        await OnCompletedAsync(command, entity);
        await Repository.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}

public class DeleteWorkplaceAddressesTranslationsForWorkplaceCommandValidator : AbstractValidator<DeleteWorkplaceAddressesTranslationsForWorkplaceCommand>
{
    public DeleteWorkplaceAddressesTranslationsForWorkplaceCommandValidator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.CultureCode)
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{nameof(DeleteWorkplaceAddressesTranslationsForWorkplaceCommand)} : {nameof(DeleteWorkplaceAddressesTranslationsForWorkplaceCommand.CultureCode)} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}