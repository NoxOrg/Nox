using Moq;
using Nox.Solution.Tests.FixtureConfig;
using Nox.Solution.Extensions;
using FluentAssertions;
using Nox.Types;
using Xunit.Sdk;

namespace Nox.Solution.Tests.Extensions;

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
        public IReadOnlyList<string> StringListProperty { get; set; } = new List<string>() { "So", "long", "and", "thanks", "for", "all", "the", "fish" };

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
        public DateTimeOffset DateTimeOffsetProperty { get; set; } = new DateTimeOffset(1952, 3, 11, 11, 10, 12, 307, 69, new TimeSpan(1, 0, 0));
        public TimeSpan TimeSpanProperty { get; set; } = new TimeSpan(1, 2, 3, 4, 5, 6);
        public double DoubleProperty { get; set; } = 3.14159265358979323;
    }

    [Fact]
    public void TestClassInstance_ToSource_Generates_Correct_Source()
    {
        // Arrange
        var instance = new TestClass();

        var expectedSource = """
                Nox.Solution.Tests.Extensions.ObjectExtensionsTests+TestClass instance2 = new ()
                {
                    IntegerProperty = 42,
                    StringProperty = "\"Life, the Universe and Everything\" \r\n\t - Douglas Adams \ud83d\ude00",
                    BoolProperty = false,
                    DecimalProperty = 1.2m,
                    GuidProperty = new System.Guid("bc92c8c8-c835-45f9-8d2f-6adccab1b97c"),
                    UrlProperty = new System.Uri("https://douglasadams.com/creations/hhgg.html"),
                    LongProperty = 627866239874251234,
                    StringListProperty = new System.Collections.Generic.List<System.String>()
                    {
                        "So",
                        "long",
                        "and",
                        "thanks",
                        "for",
                        "all",
                        "the",
                        "fish",
                    },
                    StringDictionaryProperty = new System.Collections.Generic.Dictionary<System.Int32, System.String>()
                    {
                        [1] = "The Hitch Hiker's Guide to the Galaxy",
                        [2] = "The Restaurant at the End of the Universe",
                        [3] = "Life, The Universe and Everything",
                        [4] = "So Long, and Thanks For All The Fish",
                        [5] = "Mostly Harmless",
                    },
                    NullStringProperty = "Empty void of space",
                    IntArrayProperty = new System.Int32[]
                    {
                        0,
                        1,
                        1,
                        2,
                        3,
                        5,
                        8,
                        13,
                        21,
                        34,
                        55,
                        89,
                        144,
                    },
                    DateTimeProperty = new System.DateTime(1952,3,11,11,10,12,307),
                    DateTimeOffsetProperty = new System.DateTimeOffset(1952,3,11,11,10,12,307, new System.TimeSpan(36000000000)),
                    TimeSpanProperty = new System.TimeSpan(937840050060),
                    DoubleProperty = 3.141592653589793,
                };

                """;

        // Act
        var source = instance.ToSourceCode(nameof(instance) + "2");

        // Assert
        source.Should().Be(expectedSource);
    }

    [Fact]
    public void Object_ToSource_Generates_Correct_Source()
    {
        // Arrange
        var textOptions = new TextTypeOptions()
        {
            MaxLength = 16,
            MinLength = 4,
            Casing = TextTypeCasing.Lower,
            IsLocalized = true,
            // IsUnicode = true
        };

        var expectedSource = """
                Nox.Types.TextTypeOptions textOptions2 = new ()
                {
                    MinLength = 4,
                    MaxLength = 16,
                    IsUnicode = true,
                    IsLocalized = true,
                    Casing = Nox.Types.TextTypeCasing.Lower,
                };

                """;

        // Act
        var source = textOptions.ToSourceCode(nameof(textOptions) + "2");

        // Assert
        source.Should().Be(expectedSource);
    }

    [Fact]
    public void Object_ToSource_Generates_Correct_Source_From_Solution()
    {
        // Arrange
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();

        // Act
        var source = noxConfig.ToSourceCode("solution");

        // Assert
        noxConfig.Should().NotBeNull();
        noxConfig.Version.Should().Be("2.0");
        noxConfig.PlatformId.Should().Be("Nox");

        source.Should().NotBeNull();
        source.Length.Should().BeGreaterThan(40000);
    }
}