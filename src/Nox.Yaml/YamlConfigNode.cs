using Nox.Yaml.Validation;
using YamlDotNet.Serialization;

namespace Nox.Yaml;

public class YamlConfigNode<TTopNode,TParentNode> 
    where TTopNode : class, new()
    where TParentNode : class, new()
{
    [YamlIgnore]
    public string? YamlFile { get; internal set; } 

    [YamlIgnore]
    public string? YamlContent { get; internal set; } 

    [YamlIgnore]
    public string? YamlPath { get; internal set; }

    [YamlIgnore]
    public TParentNode? Parent { get; internal set; }
    
    public virtual void SetDefaults(TTopNode topNode, TParentNode parentNode, string yamlPath) { }

    public virtual void Initialize(TTopNode topNode, TParentNode parentNode, string yamlPath) { }

    public virtual ValidationResult Validate(TTopNode topNode, TParentNode parentNode, string yamlPath) { return new ValidationResult(); }

    public bool IsTopNode()
    {
        return Parent is null || Parent.Equals(this);
    }

}
