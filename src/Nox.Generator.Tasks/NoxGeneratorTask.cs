using Microsoft.Build.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Nox.Generator.Tasks;

public class NoxGeneratorTask : ITask
{
    public IBuildEngine BuildEngine { get; set; } = default!;
    
    public ITaskHost HostObject { get; set; } = default!;

    [Required]
    public ITaskItem[] NoxYamlFiles { get; set; } = default!;

    public string OutputDirectory { get; set; } = "Nox.Generated";

    public bool Execute()
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            //Debugger.Launch();
        }
#endif

        var noxYamls = ReadNoxYamlFile();
        if (noxYamls is null)
            return false;

        var fileGenerator = new NoxFileGenerator(noxYamls, OutputDirectory);
        fileGenerator.GenerateFiles();

        return true;
    }

    private IEnumerable<string> ReadNoxYamlFile()
    {
        return NoxYamlFiles
            .Select(item => item.GetMetadata("FullPath"))
            .ToList();
    }
}