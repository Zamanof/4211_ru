using System.Net;

public class WebHost
{
    private int _port;
    private HttpHandler _handler;
    private HttpListener _listener;
    private MiddlewareBuilder _middlewareBuilder = new();

    public WebHost(int port)
    {
        _port = port;
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://localhost:{_port}/");
    }
    public void UseStartup<T>() where T: IStartup, new()
    {
        IStartup startup = new T();
        startup.Configure(_middlewareBuilder);
        _handler = _middlewareBuilder.Build();
    }

    public void Run()
    {
        _listener.Start();
        Console.WriteLine($"Server started {_port}");
        while (true)
        {
            HttpListenerContext context = _listener.GetContext();
            Task.Run(() => HandlerRequest(context));
        }
    }

    private void HandlerRequest(HttpListenerContext context)
    {
        _handler.Invoke(context);
    }
}