namespace RvdB.Heyzine.Exceptions;

public class EnvironmentVariableNotSetException : Exception
{
    public EnvironmentVariableNotSetException()
    {
    }

    public EnvironmentVariableNotSetException(string variableName)
        : base(string.Format(Constants.ERRORS_ENVVAR_NOTSET, variableName))
    {
        ArgumentNullException.ThrowIfNull(variableName, nameof(variableName));
    }

    public EnvironmentVariableNotSetException(string variableName, Exception innerException)
        : base(string.Format(Constants.ERRORS_ENVVAR_NOTSET, variableName), innerException)
    {
        ArgumentNullException.ThrowIfNull(variableName, nameof(variableName));
    }
}