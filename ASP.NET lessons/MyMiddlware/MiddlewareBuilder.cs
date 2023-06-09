public class MiddlewareBuilder
{
    private Stack<Type> middlewares = new();
    public void Use<T>() where T : IMiddleware
    {
        middlewares.Push(typeof(T));
    }
    public HttpHandler Build()
    {
        HttpHandler handler = context => context.Response.Close();
        while (middlewares.Count != 0)
        {
            var middlware = middlewares.Pop();
            IMiddleware? middleWare = Activator.CreateInstance(middlware) as IMiddleware;
            middleWare.Next = handler;
            handler = middleWare.Handle;
        }
        return handler;
    }
}
