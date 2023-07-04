using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class DataConnectionValidator: AbstractValidator<DataConnection>
    {
        public DataConnectionValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("an infrastructure, dependencies, data connection", servers));
            RuleFor(p => p.Provider)
                .NotNull()
                .WithMessage(p => string.Format(ValidationResources.DataConnectionProviderEmpty, p.Name, DataConnectionProvider.InMemory.ToNameList()));
        }
    }
}