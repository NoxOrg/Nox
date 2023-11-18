﻿using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

/// <summary>
/// Example how to add an additional property to a command
/// </summary>
public partial record CreateCountryLocalNamesForCountryCommand
{
    public string CustomField { get; set; } = string.Empty;
}


internal partial class CreateCountryLocalNamesForCountryCommandHandler
{
    public override async Task<CountryLocalNameKeyDto?> Handle(CreateCountryLocalNamesForCountryCommand request, CancellationToken cancellationToken)
    {
        /// Example how to use the custom field added to the default request
        if(string.IsNullOrEmpty(request.CustomField))
        { 
            throw new Exception("CustomField should be set on the API controller that is overriding the default beahvior");
        }
        return await base.Handle(request, cancellationToken);
    }
}