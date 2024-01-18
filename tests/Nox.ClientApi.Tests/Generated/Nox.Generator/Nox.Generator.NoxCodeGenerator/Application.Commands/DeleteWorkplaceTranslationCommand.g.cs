// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using WorkplaceLocalizedEntity = ClientApi.Domain.WorkplaceLocalized;

namespace ClientApi.Application.Commands;

public partial record  DeleteWorkplaceTranslationCommand(System.Int64 keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteWorkplaceTranslationCommandHandler : DeleteWorkplaceTranslationCommandHandlerBase
{
    public DeleteWorkplaceTranslationCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteWorkplaceTranslationCommandHandlerBase : CommandBase<DeleteWorkplaceTranslationCommand, WorkplaceLocalizedEntity>, IRequestHandler<DeleteWorkplaceTranslationCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteWorkplaceTranslationCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteWorkplaceTranslationCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(command.keyId);
        
        var entity = await DbContext.Workplaces.FindAsync(keyId);
        EntityNotFoundException.ThrowIfNull(entity, "Workplace", $"{keyId.ToString()}");
		
        var entityLocalized = await DbContext.WorkplacesLocalized.FirstOrDefaultAsync(x =>x.Id == entity.Id && x.CultureCode == command.CultureCode);
        EntityLocalizationNotFoundException.ThrowIfNull(entityLocalized, "Workplace",  $"{keyId.ToString()}", command.CultureCode.ToString());
        
        await OnCompletedAsync(command, entityLocalized);
        
        DbContext.Remove(entityLocalized);
        
        await DbContext.SaveChangesAsync(cancellationToken);
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