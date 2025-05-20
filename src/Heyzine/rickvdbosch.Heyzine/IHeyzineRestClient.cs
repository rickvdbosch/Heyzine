namespace rickvdbosch.Heyzine;

public interface IHeyzineRestClient
{
    Task<Response?> ConvertPdfAsync(Uri pdfLocation);
}