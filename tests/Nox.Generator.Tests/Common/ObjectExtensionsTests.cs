#nullable enable
using System;
using System.Collections.Generic;
using FluentAssertions;
using Nox.Solution.Extensions;
using Nox.Types;
using Xunit;
using DateTime = System.DateTime;
using Guid = System.Guid;
using Uri = System.Uri;

namespace Nox.Generator.Tests.Common;

public class ObjectExtensionsTests
{
    internal class TestClass
    {
        public int IntegerProperty { get; set; } = 42;
        public string StringProperty { get; set; } = "\"Life, the Universe and Everything\" \r\n\t - Douglas Adams 😀";
        public bool BoolProperty { get; set; } = false;
        public decimal DecimalProperty { get; set; } = 1.2m;
        public Guid GuidProperty { get; set; } = new Guid("bc92c8c8-c835-45f9-8d2f-6adccab1b97c");
        public Uri UrlProperty { get; set; } = new Uri("https://douglasadams.com/creations/hhgg.html");
        public long LongProperty { get; set; } = 62_786_623_987_425_1234;

        public IReadOnlyList<string> StringListProperty { get; set; } = new List<string>()
            { "So", "long", "and", "thanks", "for", "all", "the", "fish" };

        public IReadOnlyDictionary<int, string> StringDictionaryProperty { get; set; } = new Dictionary<int, string>()
        {
            [1] = "The Hitch Hiker's Guide to the Galaxy",
            [2] = "The Restaurant at the End of the Universe",
            [3] = "Life, The Universe and Everything",
            [4] = "So Long, and Thanks For All The Fish",
            [5] = "Mostly Harmless",
        };

        public string? NullStringProperty { get; set; } = "Empty void of space";
        public string? HiddenNullStringProperty { get; set; } = null;
        public int[] IntArrayProperty { get; set; } = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
        public DateTime DateTimeProperty { get; set; } = new DateTime(1952, 3, 11, 11, 10, 12, 307, 69);

        public DateTimeOffset DateTimeOffsetProperty { get; set; } =
            new DateTimeOffset(1952, 3, 11, 11, 10, 12, 307, 69, new TimeSpan(1, 0, 0));

        public TimeSpan TimeSpanProperty { get; set; } = new TimeSpan(1, 2, 3, 4, 5, 6);
        public double DoubleProperty { get; set; } = 3.14159265358979323;
    }

    [Fact]
    public void TestClassInstance_ToOptionProperties_Generates_Correct_Source()
    {
        // Arrange
        var testClass = new TestClass();

        // Act
        var source = testClass.ToOptionProperties();
        var generatedJson = System.Text.Json.JsonSerializer.Serialize(source);

        // Assert
        source.Should().ContainSingle(p=>p.Name == "IntegerProperty" && p.Type == "SimpleType");
        source.Should().ContainSingle(p=>p.Name == "StringProperty" && p.Type == "SimpleType");
        source.Should().ContainSingle(p=>p.Name == "BoolProperty" && p.Type == "SimpleType");
        source.Should().ContainSingle(p=>p.Name == "DecimalProperty" && p.Type == "SimpleType");
        source.Should().ContainSingle(p=>p.Name == "GuidProperty" && p.Type == "Guid");
        source.Should().ContainSingle(p=>p.Name == "UrlProperty" && p.Type == "Uri");
        source.Should().ContainSingle(p=>p.Name == "LongProperty" && p.Type == "SimpleType");
        source.Should().ContainSingle(p=>p.Name == "StringListProperty" && p.Type == "IList");
        source.Should().ContainSingle(p=>p.Name == "StringDictionaryProperty" && p.Type == "IDictionary");
        source.Should().ContainSingle(p=>p.Name == "NullStringProperty" && p.Type == "SimpleType");
        source.Should().ContainSingle(p=>p.Name == "HiddenNullStringProperty" && p.Type == string.Empty);
        source.Should().ContainSingle(p=>p.Name == "IntArrayProperty" && p.Type == "Array");
        source.Should().ContainSingle(p=>p.Name == "DateTimeProperty" && p.Type == "DateTime");
        source.Should().ContainSingle(p=>p.Name == "DateTimeOffsetProperty" && p.Type == "DateTimeOffset");
        source.Should().ContainSingle(p=>p.Name == "TimeSpanProperty" && p.Type == "TimeSpan");
        source.Should().ContainSingle(p=>p.Name == "DoubleProperty" && p.Type == "SimpleType");
        
        var expectedJson = System.IO.File.ReadAllText("./files/json/TestClassProperties.json");
        generatedJson.Should().Be(expectedJson);
    }
}