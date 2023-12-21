using AutoFixture;
using Bunit;
using FluentAssertions;
using No.Ui.Blazor.Lib.Tests.FixtureConfig;
using Nox.Ui.Blazor.Lib.Components.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Tests;

public class EditTextTests : TestContext
{
#nullable enable

    /// <summary>
    /// Bunit test which renders ui component and then checks html output of input Title is valid
    /// </summary>
    /// <param name="fixture"></param>
    [Theory]
    [AutoMoqData]
    public void When_EditText_Should_Render_Title(IFixture fixture)
    {
        // Arrange
        string expectedTitle = fixture.Create<string>();

        // Act
        var rendered = RenderComponent<EditText>(parameters => parameters
        .Add(controlParameter => controlParameter.Title, expectedTitle)
        );
        var input = rendered.Find("label");

        // Assert
        input.Should().NotBeNull();
        input.InnerHtml.Should().Be(expectedTitle);
    }

    /// <summary>
    /// BUnit test which renders ui component and then checks if TextChanged eventcallback<string> from text manual input is valid
    /// </summary>
    /// <param name="fixture"></param>
    [Theory]
    [AutoMoqData]
    public void When_EditText_Should_Update_TextChanged(IFixture fixture)
    {
        // Arrange
        string expectedText = fixture.Create<string>();
        string value = string.Empty;

        // Act
        var rendered = RenderComponent<EditText>(parameters => parameters
        .Add(controlParameter => controlParameter.Text, value)
        .Add(controlParameter => controlParameter.TextChanged, (inputString) =>
            {
                value = inputString;
            })
        );
        var input = rendered.Find("input");
        input.Change(expectedText);

        // Assert
        input.Should().NotBeNull();
        value.Should().NotBeNullOrWhiteSpace();
        value.Should().Be(expectedText);
    }

    /// <summary>
    /// BUnit test which renders ui component and then checks ValidateLength method from text manual input is validated successfully
    /// </summary>
    [Fact]
    public void When_EditText_Should_ValidateMinLength_Success()
    {
        // Arrange
        string inputText = "123";
        int inputMinLength = 3;

        // Act
        var rendered = RenderComponent<EditText>(parameters => parameters
        .Add(controlParameter => controlParameter.MinLength, inputMinLength)
        );

        var validationOutput = rendered.Instance.ValidateLength(inputText);

        // Assert
        validationOutput.Should().BeNullOrWhiteSpace();
    }

    /// <summary>
    /// BUnit test which renders ui component and then checks ValidateLength method from text manual input is validated unsuccessfully
    /// </summary>
    [Fact]
    public void When_EditText_Should_ValidateMinLength_Fail()
    {
        // Arrange
        string inputText = "123";
        int inputMinLength = 4;

        // Act
        var rendered = RenderComponent<EditText>(parameters => parameters
        .Add(controlParameter => controlParameter.MinLength, inputMinLength)
        );

        var validationOutput = rendered.Instance.ValidateLength(inputText);

        // Assert
        validationOutput.Should().NotBeNullOrWhiteSpace();
    }
}