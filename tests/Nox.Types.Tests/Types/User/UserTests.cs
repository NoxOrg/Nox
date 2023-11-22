using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class UserTests
{
    [Fact]
    public void User_Constructor_Guid_ReturnsSameValue()
    {
        var userGuidString = Guid.NewGuid().ToString();

        var user = User.From(userGuidString, new UserTypeOptions { ValidGuidFormat =true, ValidEmailFormat =false, IsCaseSensitive =true});

        user.Value.Should().Be(userGuidString);
    }

    [Fact]
    public void User_Constructor_Email_ReturnsSameValue()
    {
        var userEmailString = "user@iwgplc.com";

        var user = User.From(userEmailString, new UserTypeOptions { ValidGuidFormat = false, ValidEmailFormat = true, IsCaseSensitive = true });

        user.Value.Should().Be(userEmailString);
    }

    [Fact]
    public void User_Constructor_AnyStringCaseSensitive_ReturnsSameValue()
    {
        var userString = "QuickBrownFoxJumpedOverTheWoodenLog";

        var user = User.From(userString, new UserTypeOptions { ValidGuidFormat = false, ValidEmailFormat = false, IsCaseSensitive = true });

        user.Value.Should().Be(userString);
    }

    [Fact]
    public void User_Constructor_AnyCaseInsensitiveString_ReturnsToLower()
    {
        var userString = "QuickBrownFoxJumpedOverTheWoodenLog";

        var user = User.From(userString, new UserTypeOptions { ValidGuidFormat = false, ValidEmailFormat = false, IsCaseSensitive = false });

        user.Value.Should().Be(userString.ToLowerInvariant());
    }

    [Fact]
    public void UserTypeOptions_Constructor_ReturnsDefaults()
    {
        var userTypeOptions = new UserTypeOptions();

        userTypeOptions.MinLength = 1;
        userTypeOptions.MaxLength = 511;
        userTypeOptions.IsCaseSensitive = true;
        userTypeOptions.ValidGuidFormat = true;
        userTypeOptions.ValidEmailFormat = true;
    }

    [Fact]
    public void User_Constructor_SpecifyingMaxLength_WithLongerLengthInput_ThrowsValidationException()
    {
        var act = () => User.From("thequickbrownfoxjumpedoverthewoodenlog@iwgplc.com", new UserTypeOptions { MaxLength = 15 });
        act.Should().Throw<NoxTypeValidationException>()
            .And.Errors.First().ErrorMessage.Should().Be("Could not create a Nox User type that is 49 characters long and longer than the maximum specified length of 15.");
    }

    [Fact]
    public void User_Constructor_SpecifyingMinLength_WithShorterLengthInput_ThrowsValidationException()
    {
        var act = () => User.From("thequickbrownfoxjumpedoverthewoodenlog@iwgplc.com", new UserTypeOptions { MinLength = 50 });
        act.Should().Throw<NoxTypeValidationException>()
            .And.Errors.First().ErrorMessage.Should().Be("Could not create a Nox User type that is 49 characters long and shorter than the minimum specified length of 50.");
    }

    [Fact]
    public void User_Constructor_InvalidGuidType_ThrowsValidationException()
    {
        var act = () => User.From("thequickbrownfoxjumpedoverthewoodenlog@iwgplc.com", new UserTypeOptions { ValidGuidFormat = true, ValidEmailFormat = false, IsCaseSensitive = true });
        act.Should().Throw<NoxTypeValidationException>().And.Errors.First().ErrorMessage
            .Should().Be("Could not create a Nox User type thequickbrownfoxjumpedoverthewoodenlog@iwgplc.com as it is not a valid Guid.");
    }

    [Fact]
    public void User_Constructor_InvalidEmailType_ThrowsValidationException()
    {
        var userGuid = Guid.NewGuid().ToString();
        var act = () => User.From(userGuid, new UserTypeOptions { ValidGuidFormat = false, ValidEmailFormat = true, IsCaseSensitive = true });
        act.Should().Throw<NoxTypeValidationException>()
            .And.Errors.First().ErrorMessage
            .Should().Be($"Could not create a Nox User type {userGuid} as it is not a valid email address.");
    }

    [Fact]
    public void User_Constructor_InvalidEmailAndGuidType_ThrowsValidationException()
    {
        var userId = "AyeDee";
        var act = () => User.From(userId);
        act.Should().Throw<NoxTypeValidationException>()
            .And.Errors.First().ErrorMessage
            .Should().Be($"Could not create a Nox User type {userId} as it is not a valid guid or email address.");
    }

    [Fact]
    public void User_Equality_Guid_Tests()
    {
        var guid = Guid.NewGuid().ToString();

        var user1 = User.From(guid);

        var user2 = User.From(guid);

        user1.Should().BeEquivalentTo(user2);
    }

    [Fact]
    public void User_Equality_Email_Tests()
    {
        var emailString = "info@test-mailer.com";

        var user1 = User.From(emailString, new UserTypeOptions { ValidGuidFormat = true, ValidEmailFormat = true, IsCaseSensitive = true });

        var user2 = User.From(emailString, new UserTypeOptions { ValidGuidFormat = true, ValidEmailFormat = true, IsCaseSensitive = true });

        user1.Should().BeEquivalentTo(user2);
    }

    [Fact]
    public void User_Guid_CaseInsensitiveEquality_Tests()
    {
        var guid = Guid.NewGuid().ToString();

        var user1 = User.From(guid, new UserTypeOptions { ValidGuidFormat = true, ValidEmailFormat = false, IsCaseSensitive = false});

        var user2 = User.From(guid.ToUpperInvariant(), new UserTypeOptions { ValidGuidFormat = true, ValidEmailFormat = false, IsCaseSensitive = false });

        user1.Should().BeEquivalentTo(user2);
    }

    [Fact]
    public void User_Email_CaseInsensitiveEquality_Tests()
    {

        var user1 = User.From("info@test-mailer.com", new UserTypeOptions { IsCaseSensitive = false });

        var user2 = User.From("INFO@Test-Mailer.COM", new UserTypeOptions { IsCaseSensitive = false });

        user1.Should().BeEquivalentTo(user2);
    }

    [Fact]
    public void User_Guid_NotEqual_Tests()
    {
        var user1 = User.From(Guid.NewGuid().ToString());

        var user2 = User.From(Guid.NewGuid().ToString());

        user1.Should().NotBeEquivalentTo(user2);
    }

    [Fact]
    public void User_Email_NotEqual_Tests()
    {
        var user1 = User.From("info1@test-mailer.com");

        var user2 = User.From("info2@test-mailer.com");

        user1.Should().NotBeEquivalentTo(user2);
    }

    [Fact]
    public void User_Guid_ToString_ReturnsString()
    {
        var guidString = Guid.NewGuid().ToString();
        var user = User.From(guidString);

        user.ToString().Should().BeEquivalentTo(guidString);
    }

    [Fact]
    public void User_Email_ToString_ReturnsString()
    {
        var user = User.From("info1@test-mailer.com");

        user.ToString().Should().BeEquivalentTo("info1@test-mailer.com");
    }
}
