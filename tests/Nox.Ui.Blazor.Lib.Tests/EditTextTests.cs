using AutoFixture;
using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components.Web;
using No.Ui.Blazor.Lib.Tests.FixtureConfig;
using Nox.Ui.Blazor.Lib.Components.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Tests;

public class EditTextTests
{
#nullable enable

    [Theory]
    [AutoMoqData]
    public void When_EditText_Should_Render_Title(IFixture fixture)
    {
        // Arrange
        using var context = new TestContext();
        string expectedTitle = fixture.Create<string>();

        // Act
        var rendered = context.RenderComponent<EditText>(parameters => parameters
        .Add(controlParameter => controlParameter.Title, expectedTitle)
        );
        var input = rendered.Find("label");

        // Assert
        input.Should().NotBeNull();
        input.InnerHtml.Should().Be(expectedTitle);
    }
}