namespace rickvdbosch.Heyzine.Exceptions;

public class EnvironmentVariableNotSetException : Exception
{
    public EnvironmentVariableNotSetException()
    {
    }

    public EnvironmentVariableNotSetException(string variableName)
        : base($"Environment variable {variableName} has not been configured correctly.")
    {
    }

    public EnvironmentVariableNotSetException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}