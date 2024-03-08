// Generated

#nullable enable

using AutoMapper;
using Nox.Integration.Abstractions.Interfaces;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public partial class TestIntegrationTransform: TestIntegrationTransformBase, INoxCustomTransformHandler
{
    public virtual dynamic Invoke(dynamic sourceRecord)
    {
        return InvokeBase(sourceRecord);
    }
}