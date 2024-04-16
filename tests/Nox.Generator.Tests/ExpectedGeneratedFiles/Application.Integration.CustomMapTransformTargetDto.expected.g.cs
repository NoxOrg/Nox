// Generated

#nullable enable

using ETLBox.DataFlow;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public sealed class TestIntegrationTargetDto: MergeableRow
{
    public System.Int32 TargetId { get; set; }
    public System.Double? TargetDouble { get; set; }
    public System.Boolean? TargetBool { get; set; }
    public System.String? TargetString { get; set; }
    public System.String RequiredTargetString { get; set; } = String.Empty;
    public System.DateOnly? TargetDate { get; set; }
    public System.TimeOnly? TargetTime { get; set; }
    public System.DateTime? TargetDateTime { get; set; }
    public System.Guid? TargetGuid { get; set; }
    public System.Int32? TargetCalculated { get; set; }
}