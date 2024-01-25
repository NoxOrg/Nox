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
using TestWebApp.Domain;
using TestEntityLocalizationLocalizedEntity = TestWebApp.Domain.TestEntityLocalizationLocalized;

namespace TestWebApp.Application.Commands;

public partial record  DeleteTestEntityLocalizationTranslationCommand(System.String keyId, Nox.Types.CultureCode CultureCode) : IRequest<bool>;

internal partial class DeleteTestEntityLocalizationTranslationCommandHandler : DeleteTestEntityLocalizationTranslationCommandHandlerBase
{
    public DeleteTestEntityLocalizationTranslationCommandHandler(
           IRepository repository,
                  NoxSolution noxSolution) : base(repository, noxSolution)
    {
    }
}

internal abstract class DeleteTestEntityLocalizationTranslationCommandHandlerBase : CommandBase<DeleteTestEntityLocalizationTranslationCommand, TestEntityLocalizationLocalizedEntity>, IRequestHandler<DeleteTestEntityLocalizationTranslationCommand, bool>
{
    public IRepository Repository { get; }

    public DeleteTestEntityLocalizationTranslationCommandHandlerBase(
           IRepository repository,
                  NoxSolution noxSolution) : base(noxSolution)
    {
        Repository = repository;
    }

    public virtual async Task<bool> Handle(DeleteTestEntityLocalizationTranslationCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await OnExecutingAsync(command);
		var keyId = Dto.TestEntityLocalizationMetadata.CreateId(command.keyId);
        
        var entity = await Repository.FindAsync<TestEntityLocalization>(keyId);
        EntityNotFoundException.ThrowIfNull(entity, "TestEntityLocalization", $"{keyId.ToString()}");
		
        var entityLocalized = await Repository.Query<TestEntityLocalizationLocalized>().FirstOrDefaultAsync(x =>x.Id == entity.Id && x.CultureCode == command.CultureCode);
        EntityLocalizationNotFoundException.ThrowIfNull(entityLocalized, "TestEntityLocalization",  $"{keyId.ToString()}", command.CultureCode.ToString());
        
        Repository.Delete(entityLocalized);
        await OnCompletedAsync(command, entityLocalized);
        await Repository.SaveChangesAsync(cancellationToken);
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