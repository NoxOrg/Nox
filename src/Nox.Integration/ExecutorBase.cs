using System.Dynamic;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Transformations;

namespace Nox.Integration;

public abstract class ExecutorBase
{
    private readonly Solution.Integration _definition;
    
    protected ExecutorBase(Solution.Integration definition)
    {
        _definition = definition;
    }

    public void IncludeTransformation(IDataFlowExecutableSource<ExpandoObject> dataSource)
    {
        if (_definition.Transform is { Mappings: not null } && _definition.Transform!.Mappings.Any())
        {
            var map = new ColumnRename<ExpandoObject>
            {
                RenameColumns = new List<RenameColumn>()
            };
            
            foreach (var mapping in _definition.Transform.Mappings)
            {
                map.RenameColumns.Add(new RenameColumn
                {
                    CurrentName = mapping.SourceColumn,
                    NewName = mapping.TargetAttribute,
                });
            }

            var converters = _definition.Transform.Mappings.Where(m => m.Converter != null).ToList();
            if (converters.Any())
            {
                foreach (var converter in converters)
                {
                    var rowTransform = new RowTransformation<ExpandoObject>(row =>
                    {
                        var namedRow = (IDictionary<string, object>)row!;
                        switch (converter.Converter)
                        {
                            case IntegrationMappingConverter.LowerCase:
                                namedRow[converter.TargetAttribute] = namedRow[converter.SourceColumn].ToString()!.ToLower();
                                break;
                            case IntegrationMappingConverter.UpperCase:
                                namedRow[converter.TargetAttribute] = namedRow[converter.SourceColumn].ToString()!.ToUpper();
                                break;
                        }
                        return (ExpandoObject)namedRow!;
                    });
                    dataSource.LinkTo(rowTransform);
                }
                
                //new
                // var rowTransform = new RowTransformation
                // {
                //     TransformationFunc = TransformationFunc
                // };
            }
            dataSource.LinkTo(map);
        }
    }

    // private ExpandoObject TransformationFunc(ExpandoObject arg)
    // {
    //     
    // }
}