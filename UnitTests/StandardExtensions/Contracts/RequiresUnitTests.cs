namespace UnitTests.StandardExtensions.Contracts;

/// <summary>
/// Unit tests for Requires class.
/// </summary>
public class RequiresUnitTests
{
    [Theory(DisplayName = "Test e-mail validation")]
    [InlineData("test@testerson.com", true)]
    [InlineData("test@caractere-românești.com", true)]
    [InlineData("/test@testerson.com", true)]
    [InlineData("test/@testerson.com", true)]
    [InlineData("test@/testerson.com", false)]
    [InlineData("test@testerson/.com", false)]
    [InlineData("test@testerson./com", false)]
    [InlineData("t/est@testerson.com", true)]
    [InlineData("simple@example.com", true)]
    [InlineData("very.common@example.com", true)]
    [InlineData("disposable.style.email.with+symbol@example.com", true)]
    [InlineData("other.email-with-hyphen@example.com", true)]
    [InlineData("fully-qualified-domain@example.com", true)]
    [InlineData("user.name+tag+sorting@example.com", true)]
    [InlineData("x@example.com", true)]
    [InlineData("example-indeed@strange-example.com", true)]
    [InlineData("test/test@test.com", true)]
    [InlineData("admin@mailserver1", true)]
    [InlineData("example@s.example", true)]
    [InlineData("\" \"@example.org", true)]
    [InlineData("\"john..doe\"@example.org", true)]
    [InlineData("mailhost!username@example.org", true)]
    [InlineData("user%example.com@example.org", true)]
    [InlineData("user-@example.org", true)]
    [InlineData("postmaster@[123.123.123.123]", true)]
    [InlineData("postmaster@[IPv6:2001:0db8:85a3:0000:0000:8a2e:0370:7334]", true)]
    [InlineData("Abc.example.com", false)]
    [InlineData("A@b@c@example.com", false)]
    [InlineData("a\"b(c)d,e:f;g<h>i[j\\k]l@example.com", false)]
    [InlineData("just\"not\"right@example.com", false)]
    [InlineData("this is\"not\\allowed@example.com", false)]
    [InlineData("this\\ still\\\"not\\\\allowed@example.com", false)]
    [InlineData("1234567890123456789012345678901234567890123456789012345678901234+x@example.com", false)]
    [InlineData("i_like_underscore@but_its_not_allowed_in_this_part.example.com", false)]
    public void Test10(string email, bool expectedResult)
    {
        try
        {
            _ = Requires.ValidEmailAddress(email);
        }
        catch (ArgumentDoesNotMatchException)
        {
            Assert.False(expectedResult, "Expected validation to succeed, but it didn't.");

            return;
        }

        Assert.True(expectedResult, "Expected validation to fail, but it didn't.");
    }

    [Theory(DisplayName = "Test e-mail strict validation")]
    [InlineData("test@testerson.com", true)]
    [InlineData("test@testerson.net", true)]
    [InlineData("test@testerson.org", true)]
    [InlineData("test@testerson.ro", true)]
    [InlineData("test@testerson.co.uk", true)]
    [InlineData("test@testerson.alabalaportocala", false)]
    [InlineData("test@caractere-românești.com", true)]
    [InlineData("/test@testerson.com", true)]
    [InlineData("test/@testerson.com", true)]
    [InlineData("test@/testerson.com", false)]
    [InlineData("test@testerson/.com", false)]
    [InlineData("test@testerson./com", false)]
    [InlineData("t/est@testerson.com", true)]
    [InlineData("simple@example.com", true)]
    [InlineData("very.common@example.com", true)]
    [InlineData("disposable.style.email.with+symbol@example.com", true)]
    [InlineData("other.email-with-hyphen@example.com", true)]
    [InlineData("fully-qualified-domain@example.com", true)]
    [InlineData("user.name+tag+sorting@example.com", true)]
    [InlineData("x@example.com", true)]
    [InlineData("example-indeed@strange-example.com", true)]
    [InlineData("test/test@test.com", true)]
    [InlineData("admin@mailserver1", false)]
    [InlineData("example@s.example", false)]
    [InlineData("\" \"@example.org", true)]
    [InlineData("\"john..doe\"@example.org", true)]
    [InlineData("mailhost!username@example.org", true)]
    [InlineData("user%example.com@example.org", true)]
    [InlineData("user-@example.org", true)]
    [InlineData("postmaster@[123.123.123.123]", true)]
    [InlineData("postmaster@[IPv6:2001:0db8:85a3:0000:0000:8a2e:0370:7334]", true)]
    [InlineData("Abc.example.com", false)]
    [InlineData("A@b@c@example.com", false)]
    [InlineData("a\"b(c)d,e:f;g<h>i[j\\k]l@example.com", false)]
    [InlineData("just\"not\"right@example.com", false)]
    [InlineData("this is\"not\\allowed@example.com", false)]
    [InlineData("this\\ still\\\"not\\\\allowed@example.com", false)]
    [InlineData("1234567890123456789012345678901234567890123456789012345678901234+x@example.com", false)]
    [InlineData("i_like_underscore@but_its_not_allowed_in_this_part.example.com", false)]
    public void Test11(string email, bool expectedResult)
    {
        try
        {
            _ = Requires.ValidEmailAddressStrict(email);
        }
        catch (ArgumentDoesNotMatchException)
        {
            Assert.False(expectedResult, "Expected validation to succeed, but it didn't.");

            return;
        }

        Assert.True(expectedResult, "Expected validation to fail, but it didn't.");
    }
}