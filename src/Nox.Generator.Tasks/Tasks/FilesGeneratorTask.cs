using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Nox.Generator.Tasks;

public class FilesGeneratorTask : ITask
{
    public IBuildEngine BuildEngine { get; set; } = default!;
    public ITaskHost HostObject { get; set; } = default!;

    [Required]
    public ITaskItem[] NoxYamlFiles { get; set; } = default!;

    public bool Execute()
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
#endif

        var noxYamls = ReadNoxYamlFile();
        if (noxYamls is null)
            return false;

        var fileGenerator = new NoxFileGenerator(noxYamls);
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