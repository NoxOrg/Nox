using System.ComponentModel.DataAnnotations;
using Nox.Types;

namespace Nox.Localization.Tests.Common;

public class TestEntity
{
    [Key]
    public Number Id { get; set; }

    public Text? Name { get; set; }
}