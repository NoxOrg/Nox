using System.Dynamic;
using System.Reflection.Emit;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Transformations;

namespace Nox.Integration;

public abstract class ExecutorBase
{
    private readonly Solution.Integration _definition;
    private DynamicMethod _rowTransformDynamicMethod;
    
    protected ExecutorBase(Solution.Integration definition)
    {
        _definition = definition;
        _rowTransformDynamicMethod = new DynamicMethod("RowTransformDynamicMethod", typeof(void), new Type[] { typeof(ExpandoObject) }, typeof(ExpandoObject).Module);
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
                var rowTransform = new RowTransformation<ExpandoObject>(RowTransformationFunc);
                
                foreach (var converter in converters)
                {
                    switch (converter.Converter)
                    {
                        case IntegrationMappingConverter.LowerCase:
                            rowDictionary[converter.TargetAttribute] = rowDictionary[converter.SourceColumn].ToString()!.ToLower();
                            break;
                        case IntegrationMappingConverter.UpperCase:
                            rowDictionary[converter.TargetAttribute] = rowDictionary[converter.SourceColumn].ToString()!.ToUpper();
                            break;
                    }
                }
                dataSource.LinkTo(rowTransform);
            }
            dataSource.LinkTo(map);
        }
    }

    private ExpandoObject RowTransformationFunc(ExpandoObject arg)
    {
        throw new NotImplementedException();
    }

    private void AddUppercaseConvert()
    {
        
    }

    private void AddLowercaseConvert()
    {
        
    }
}