// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of countries.
/// </summary>
public partial class Country : AuditableEntityBase
{
    
    /// <summary>
    /// (Required)
    /// </summary>
    public Nuid Id
    {
      get => _id ??= Nuid.From(string.Join(".", Name.Value.ToString(), FormalName.Value.ToString()));
      private set
        {
            var actualNuid = Nuid.From(string.Join(".", Name.Value.ToString(), FormalName.Value.ToString()));
            if (value is null)
            {
                _id = actualNuid;
            }
            else if (value is not null && _id is null)
            {
                _id = value;
            }
            else if (value is not null && _id is not null && _id != value)
            {
                throw new InvalidOperationException("Nuid has diffrent value than it has been generated.");
            }
        }
    }
    private Nuid? _id  = null;
    
    /// <summary>
    /// The country's common name (required).
    /// </summary>
    public Text Name { get; set; } = null!;
    
    /// <summary>
    /// The country's official name (required).
    /// </summary>
    public Text FormalName { get; set; } = null!;
}
