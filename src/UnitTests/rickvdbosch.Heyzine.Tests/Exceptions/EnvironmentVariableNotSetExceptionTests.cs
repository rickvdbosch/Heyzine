using rickvdbosch.Heyzine.Exceptions;

namespace rickvdbosch.Heyzine.Tests.Exceptions;

public class EnvironmentVariableNotSetExceptionTests
{
    #region Constants

    const string defaultExceptionMessage = "Exception of type 'rickvdbosch.Heyzine.Exceptions.EnvironmentVariableNotSetException' was thrown.";
    const string defaultCustomExceptionMessage = "This is the default exception message.";
    const string variableName = "HeyzineTestVariable";

    Exception innerException = new("Inner exception");

    #endregion

    [Fact]
    public void Constructor_ShouldInitializeException()
    {
        var exception = new EnvironmentVariableNotSetException();

        Assert.NotNull(exception);
        Assert.IsType<EnvironmentVariableNotSetException>(exception);
        Assert.Equal(defaultExceptionMessage, exception.Message);
        Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ConstructorWithValidVariableName_ShouldInitializeException()
    {
        var exception = new EnvironmentVariableNotSetException(variableName);

        Assert.NotNull(exception);
        Assert.IsType<EnvironmentVariableNotSetException>(exception);
        Assert.Equal(string.Format(Constants.ERRORS_ENVVAR_NOTSET, variableName), exception.Message);
    }

    [Fact]
    public void ConstructorWithMessageAndInnerException_ShouldInitializeException()
    {
        var exception = new EnvironmentVariableNotSetException(defaultCustomExceptionMessage, innerException);

        Assert.NotNull(exception);
        Assert.IsType<EnvironmentVariableNotSetException>(exception);
        Assert.Equal(defaultCustomExceptionMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}
