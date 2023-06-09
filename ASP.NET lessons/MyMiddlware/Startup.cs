class Startup : IStartup
{
    public void Configure(MiddlewareBuilder builder)
    {
        builder.Use<LoggerMiddleware>();
        builder.Use<StaticFilesMiddleware>();
    }
}
