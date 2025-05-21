using RvdB.Heyzine.Exceptions;

namespace rickvdbosch.Heyzine.Tests.Exceptions;

public class EnvironmentVariableNotSetExceptionTests
{
    #region Constants

    const string defaultExceptionMessage = "Exception of type 'rickvdbosch.Heyzine.Exceptions.EnvironmentVariableNotSetException' was thrown.";
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
    public void Constructor_WhenValidVariableName_ShouldInitializeException()
    {
        var exception = new EnvironmentVariableNotSetException(variableName);

        Assert.NotNull(exception);
        Assert.IsType<EnvironmentVariableNotSetException>(exception);
        Assert.Equal(string.Format(Constants.ERRORS_ENVVAR_NOTSET, variableName), exception.Message);
    }

    [Fact]
    public void Constructor_WhenVariableNameNull_ShouldThrowArgumentNullException()
    {
        string? variableName = null;

        var exception = Assert.Throws<ArgumentNullException>(() => new EnvironmentVariableNotSetException(variableName));

        Assert.Equal("variableName", exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenValidMessageAndInnerException_ShouldInitializeException()
    {
        var exception = new EnvironmentVariableNotSetException(variableName, innerException);

        Assert.NotNull(exception);
        Assert.IsType<EnvironmentVariableNotSetException>(exception);
        Assert.Equal(string.Format(Constants.ERRORS_ENVVAR_NOTSET, variableName), exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }
}
