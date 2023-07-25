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

            var transforms = _definition.Transform.Mappings.Where(m => m.Converter != null).ToList();
            if (transforms.Any())
            {
                foreach (var transform in transforms)
                {
                    switch (transform.Converter)
                    {
                        case IntegrationMappingConverter.LowerCase:
                            namedRow[transform.TargetAttribute] = namedRow[transform.SourceColumn].ToString()!.ToLower();
                            break;
                        case IntegrationMappingConverter.UpperCase:
                            namedRow[transform.TargetAttribute] = namedRow[transform.SourceColumn].ToString()!.ToUpper();
                            break;
                    }

                        
                }
                
                var rowTransform = new RowTransformation
                {
                    TransformationFunc = TransformationFunc
                };

                var old = new RowTransformation<ExpandoObject>(row =>
                {
                    
                    var namedRow = (IDictionary<string, object>)row!;
                    
                    return (ExpandoObject)namedRow!;
                });
                dataSource.LinkTo(rowTransform);
            }
            dataSource.LinkTo(map);
        }
    }

    private ExpandoObject TransformationFunc(ExpandoObject arg)
    {
        
    }
}