using System.Net;

public delegate void HttpHandler(HttpListenerContext context);
public interface IMiddleware
{
    public HttpHandler Next { get; set; }
    public void Handle(HttpListenerContext context);

}
