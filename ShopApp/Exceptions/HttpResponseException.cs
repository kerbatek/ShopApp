namespace ShopApp.Exceptions;

public class HttpResponseException : Exception
{
    public int StatusCode { get; }
    public bool DisplayError { get; }
    public HttpResponseException(int statusCode, string message, bool displayError = false)
        : base(message)
    {
        StatusCode = statusCode;
        DisplayError = displayError;
    }
}