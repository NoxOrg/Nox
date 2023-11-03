using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Services;

public class NoxIntegration: INoxIntegration
{
    public string Name { get; }
    public string? Description { get; }
    public IntegrationMergeType MergeType { get; }
    public INoxReceiveAdapter? ReceiveAdapter { get; set; }
    public INoxSendAdapter? SendAdapter { get; set; }

    public NoxIntegration(string name, string? description, IntegrationMergeType mergeType)
    {
        Name = name;
        Description = description;
        MergeType = mergeType;
    }
    
    public async Task<bool> ExecuteAsync()
    {
        var source = ReceiveAdapter!.DataFlowSource;
        var result = false;
        
        switch (MergeType)
        {
            case IntegrationMergeType.MergeNew:
                result = await ExecuteMergeNew();
                break;
            case IntegrationMergeType.AddNew:
                result = await ExecuteAddNew();
                break;
        }

        return result;
    }

    private Task<bool> ExecuteMergeNew()
    {
        //todo get merge state
        return Task.FromResult(true);

    } 
    
    private Task<bool> ExecuteAddNew()
    {
        return Task.FromResult(true);
    } 
    
}