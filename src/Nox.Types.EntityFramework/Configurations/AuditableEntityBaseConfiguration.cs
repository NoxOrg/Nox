using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Types.EntityFramework.Configurations;

public class AuditableEntityBaseConfiguration : IEnumerable<NoxSimpleTypeDefinition>
{
    private readonly List<NoxSimpleTypeDefinition> _configuration;

    public AuditableEntityBaseConfiguration()
    {
        _configuration = new List<NoxSimpleTypeDefinition>
        {
            CreateUtcDateTimeDefinition(name: "CreatedAtUtc", isRequired: true),
            CreateUserDefinition(name: "CreatedBy", isRequired: true),
            CreateSystemDefinition(name: "CreatedVia", isRequired: true),

            CreateUtcDateTimeDefinition(name: "LastUpdatedAtUtc"),
            CreateUserDefinition(name: "LastUpdatedBy"),
            CreateSystemDefinition(name: "LastUpdatedVia"),

            CreateUtcDateTimeDefinition(name: "DeletedAtUtc"),
            CreateUserDefinition(name: "DeletedBy"),
            CreateSystemDefinition(name: "DeletedVia"),
        };
    }

    private static NoxSimpleTypeDefinition CreateUtcDateTimeDefinition(string name, bool isRequired = false)
        => new()
        {
            Name = name,
            Type = NoxType.DateTime,
            IsRequired = isRequired,
            DateTimeTypeOptions = new DateTimeTypeOptions(),
        };

    private static NoxSimpleTypeDefinition CreateUserDefinition(string name, bool isRequired = false)
        => new()
        {
            Name = name, 
            Type = NoxType.User,
            IsRequired = isRequired,
            UserTypeOptions = new UserTypeOptions
            {
                MaxLength = 255,
            },
        };

    private static NoxSimpleTypeDefinition CreateSystemDefinition(string name, bool isRequired = false)
        => new()
        {
            Name = name,
            Type = NoxType.Text,
            IsRequired = isRequired,
            TextTypeOptions = new TextTypeOptions
            {
                IsUnicode = false,
                MaxLength = 255,
            },
        };

    public IEnumerator<NoxSimpleTypeDefinition> GetEnumerator()
        => _configuration.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
