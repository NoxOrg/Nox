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
using ClientApi.Domain;
using WorkplaceLocalizedEntity = ClientApi.Domain.WorkplaceLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteWorkplaceTranslationCommand(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteWorkplaceTranslationCommandHandler : DeleteWorkplaceTranslationCommandHandlerBase
{
    public DeleteWorkplaceTranslationCommandHandler(
           IRepository repository,
                  NoxSolution noxSolution) : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteWorkplaceTranslationCommandHandlerBase : CommandBase<DeleteWorkplaceTranslationCommand, WorkplaceLocalizedEntity>, IRequestHandler<DeleteWorkplaceTranslationCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteWorkplaceTranslationCommandHandlerBase(
           IRepository repository,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteWorkplaceTranslationCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var keyId = Dto.WorkplaceMetadata.CreateId(command.keyId);
        
        var entity = await Repository.FindAsync<ClientApi.Domain.Workplace>(keyId);
        EntityNotFoundException.ThrowIfNull(entity, "Workplace", $"{keyId.ToString()}");
		
        var entityLocalized = await Repository.Query<WorkplaceLocalized>().FirstOrDefaultAsync(x =>x.Id == entity.Id && x.CultureCode == command.CultureCode);
        EntityLocalizationNotFoundException.ThrowIfNull(entityLocalized, "Workplace",  $"{keyId.ToString()}", command.CultureCode.ToString());
        
        Repository.Delete(entityLocalized);
        await OnCompletedAsync(command, entityLocalized);
        await Repository.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteWorkplaceTranslationCommandValidator : AbstractValidator<DeleteWorkplaceTranslationCommand>
{
    public DeleteWorkplaceTranslationCommandValidator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.CultureCode)
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{nameof(DeleteWorkplaceTranslationCommand)} : {nameof(DeleteWorkplaceTranslationCommand.CultureCode)} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}	