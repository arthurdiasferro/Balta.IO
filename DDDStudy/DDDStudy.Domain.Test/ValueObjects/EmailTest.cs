using Domain.ValueObjects;

namespace Domain.Test.ValueObjects;

[TestClass]
public class EmailTest
{
    private const string EmptyEmail = "";
    private const string InvalidEmail = "naotemcomo";
    private const string ValidEmail = "valid@example.com";
    private const string NullEmail = null!;

    [TestMethod]
    public void ShouldFailWhenEmailIsNull()
    {
        Assert.Throws<Exception>(() => new Email(NullEmail));
    }

    [TestMethod]
    public void ShouldFailWhenEmailIsEmpty()
    {
        Assert.Throws<Exception>(() => new Email(EmptyEmail));
    }

    [TestMethod]
    public void ShouldFailWhenEmailIsInvalid()
    {
        Assert.Throws<Exception>(() => new Email(InvalidEmail));
    }

    [TestMethod]
    public void ShouldSucceedWhenEmailIsValid()
    {
        Assert.IsNotNull(new Email(ValidEmail));
    }
}