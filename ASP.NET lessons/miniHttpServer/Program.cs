using System.Net;
new WebHost(27001).Run();

class WebHost
{
    int port;
    string pathBase = @"C:/Users/zamanov/WebstormProjects/4211_ru/HTML_CSS/Lesson 7/";
    HttpListener listener;
    public WebHost(int port)
    {
        this.port = port;
    }
    public void Run()
    {
        listener = new HttpListener();
        listener.Prefixes.Add($@"http://localhost:{port}/");
        listener.Start();
        Console.WriteLine($"Http server started on {port}.");
        while (true)
        {
            var context = listener.GetContext();
            Task.Run(() => {
                HandleRequest(context);
            });
        }
    }

    private void HandleRequest(HttpListenerContext context)
    {
        var url = context.Request.RawUrl;
        var path = $@"{pathBase}{url.Split('/').Last()}";
        Console.WriteLine(path);
        var responce = context.Response;
        StreamWriter streamWriter = new StreamWriter(responce.OutputStream);
        try
        {
            var src = File.ReadAllText(path);
            streamWriter.Write(src);
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
            var src = $@"{pathBase}404.html";
            Console.WriteLine(src);
            streamWriter.Write(src);
        }
        finally
        {
            streamWriter.Close();
        }
    }
}
