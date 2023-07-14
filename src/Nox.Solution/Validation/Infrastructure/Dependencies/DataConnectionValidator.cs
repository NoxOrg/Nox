using System;
using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Builders;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class DataConnectionValidator: AbstractValidator<DataConnection>
    {
        public DataConnectionValidator(IEnumerable<ServerBase>? servers)
        {
            Include(new ServerBaseValidator("an infrastructure, dependencies, data connection", servers));
            RuleFor(dc => dc.Provider)
                .NotNull()
                .WithMessage(dc => string.Format(ValidationResources.DataConnectionProviderEmpty, dc.Name, DataConnectionProvider.InMemory.ToNameList()));

            RuleFor(dc => dc.ServerUri)
                .Must(BeValidFileUri)
                .WithMessage(dc => string.Format(ValidationResources.DataConnectionInvalidFileUri, dc.Name))
                .When(dc => dc.Provider is 
                    DataConnectionProvider.CsvFile or 
                    DataConnectionProvider.ExcelFile or 
                    DataConnectionProvider.JsonFile or 
                    DataConnectionProvider.ParquetFile or
                    DataConnectionProvider.XmlFile);
        }

        private bool BeValidFileUri(DataConnection toEvaluate, string uriString)
        {
            var isValid = Uri.TryCreate(uriString, UriKind.Absolute, out var uri);
            if (isValid)
            {

                return (uri!.Scheme.ToLower()) switch
                {
                    "http" => true,
                    "https" => true,
                    "file" => true,
                    "blob" => true,
                    _ => false
                };
            }

            return uriString.StartsWith("file:.");
        }
    }
}