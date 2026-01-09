using System.Net;

namespace AndroidSSLRepro.Models;

public record UrlVerificationResult(bool Success)
{
    public Exception? Exception { get; set; }
    
    public HttpStatusCode? StatusCode { get; set; }
};