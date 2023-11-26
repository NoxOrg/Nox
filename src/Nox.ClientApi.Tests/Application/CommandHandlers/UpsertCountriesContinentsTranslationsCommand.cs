using Nox.Types;

namespace ClientApi.Application.Commands;

internal partial class UpsertCountriesContinentsTranslationsCommandHandler
{
    public override Task<CultureCode> Handle(UpsertCountriesContinentsTranslationsCommand command, CancellationToken cancellationToken)
    {
        return base.Handle(command, cancellationToken);
    }
}