using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

internal class LocalizationsValidator : AbstractValidator<UiLocalizations>
{
    public LocalizationsValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the translation, localization, database server", servers));
        RuleFor(p => p.Provider)
            .NotNull()
            .WithMessage(p => string.Format(ValidationResources.DatabaseServerProviderEmpty, p.Name, DatabaseServerProvider.SqlServer.ToNameList()));
    }
}