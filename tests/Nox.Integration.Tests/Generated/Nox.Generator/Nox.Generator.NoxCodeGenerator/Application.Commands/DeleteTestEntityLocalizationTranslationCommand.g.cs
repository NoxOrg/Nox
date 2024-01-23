// Generated

#nullable enable

using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestEntityLocalizationLocalizedEntity = TestWebApp.Domain.TestEntityLocalizationLocalized;

namespace TestWebApp.Application.Commands;

public partial record  DeleteTestEntityLocalizationTranslationCommand(System.String keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTestEntityLocalizationTranslationCommandHandler : DeleteTestEntityLocalizationTranslationCommandHandlerBase
{
    public DeleteTestEntityLocalizationTranslationCommandHandler(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(dbContext, noxSolution)
    {
    }
}

internal abstract class DeleteTestEntityLocalizationTranslationCommandHandlerBase : CommandBase<DeleteTestEntityLocalizationTranslationCommand, TestEntityLocalizationLocalizedEntity>, IRequestHandler<DeleteTestEntityLocalizationTranslationCommand, bool>
{
    public AppDbContext DbContext { get; }

    public DeleteTestEntityLocalizationTranslationCommandHandlerBase(
           AppDbContext dbContext,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        DbContext = dbContext;
    }

    public virtual async Task<bool> Handle(DeleteTestEntityLocalizationTranslationCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var keyId = Dto.TestEntityLocalizationMetadata.CreateId(command.keyId);
        
        var entity = await DbContext.TestEntityLocalizations.FindAsync(keyId);
        EntityNotFoundException.ThrowIfNull(entity, "TestEntityLocalization", $"{keyId.ToString()}");
		
        var entityLocalized = await DbContext.TestEntityLocalizationsLocalized.FirstOrDefaultAsync(x =>x.Id == entity.Id && x.CultureCode == command.CultureCode);
        EntityLocalizationNotFoundException.ThrowIfNull(entityLocalized, "TestEntityLocalization",  $"{keyId.ToString()}", command.CultureCode.ToString());
        
        await OnCompletedAsync(command, entityLocalized);
        
        DbContext.Remove(entityLocalized);
        
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

public class DeleteTestEntityLocalizationTranslationCommandValidator : AbstractValidator<DeleteTestEntityLocalizationTranslationCommand>
{
    public DeleteTestEntityLocalizationTranslationCommandValidator(NoxSolution noxSolution)
    {
        var defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);

		RuleFor(x => x.CultureCode)
			.Must(x => x != defaultCultureCode)
			.WithMessage($"{nameof(DeleteTestEntityLocalizationTranslationCommand)} : {nameof(DeleteTestEntityLocalizationTranslationCommand.CultureCode)} cannot be the default culture code: {defaultCultureCode.Value}.");
			
    }
}	