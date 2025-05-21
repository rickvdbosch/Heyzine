namespace RvdB.Heyzine;

public interface IHeyzineRestClient
{
    Task<Response?> ConvertPdfAsync(Uri pdfLocation);
}