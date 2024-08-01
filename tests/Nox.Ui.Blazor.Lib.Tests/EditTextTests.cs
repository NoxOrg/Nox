using AutoFixture;
using Bunit;
using FluentAssertions;
using No.Ui.Blazor.Lib.Tests.FixtureConfig;
using Nox.Ui.Blazor.Lib.Components.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Tests;

public class UiTextFixture
{
    public IFixture Fixture { get; }

    public UiTextFixture() 
    {
        Fixture = new Fixture();
    }
}

public class EditTextTests : TestContext, IClassFixture<UiTextFixture>
{
    private UiTextFixture _fixture { get; }

    public EditTextTests(UiTextFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Bunit test which renders ui component and then checks html output of input Title is valid
    /// </summary>
    [Fact(Skip = "System.InvalidOperationException : Cannot provide a value for property 'Localizer' on type 'MudBlazor.MudInput`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]'. There is no registered service of type 'MudBlazor.InternalMudLocalizer'.")]
    public void When_EditText_Should_Render_Title() 
    {
        // Arrange
        string expectedTitle = _fixture.Fixture.Create<string>();

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
    [Fact(Skip = "System.InvalidOperationException : Cannot provide a value for property 'Localizer' on type 'MudBlazor.MudInput`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]'. There is no registered service of type 'MudBlazor.InternalMudLocalizer'.")]
    public void When_EditText_Should_Update_TextChanged()
    {
        // Arrange
        string expectedText = _fixture.Fixture.Create<string>();
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
    [Fact(Skip = "System.InvalidOperationException : Cannot provide a value for property 'Localizer' on type 'MudBlazor.MudInput`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]'. There is no registered service of type 'MudBlazor.InternalMudLocalizer'.")]
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
    [Fact(Skip = "System.InvalidOperationException : Cannot provide a value for property 'Localizer' on type 'MudBlazor.MudInput`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]'. There is no registered service of type 'MudBlazor.InternalMudLocalizer'.")]
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