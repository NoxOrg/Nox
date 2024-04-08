// Generated

#nullable enable

using Nox.Integration.Abstractions.Interfaces;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public sealed class TestIntegrationTargetDto: INoxTransformDto
{
    public System.Int32? IntField { get; set; }
    public System.Double? DoubleField { get; set; }
    public System.Boolean? BoolField { get; set; }
    public System.String? StringField { get; set; }
    public System.DateOnly? DateField { get; set; }
    public System.TimeOnly? TimeField { get; set; }
    public System.DateTime? DateTimeField { get; set; }
    public System.Guid? GuidField { get; set; }
    public System.Double? CalculatedValue { get; set; }
}