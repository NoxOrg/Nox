﻿using System.Collections.Generic;

namespace Nox.Generator.Tests.Flows;

public interface IGeneratorTestFlow
{
    IGeneratorTestFlow AssertOutputResult();

    IGeneratorTestFlow AssertFileExistence(int expectedFileCount, params string[] fileNames);

    IGeneratorContentTestFlow AssertContent();

    IDictionary<string,string> Sources { get; }
}