using ToDo_WEB_API.Data;

namespace ToDo_WEB_API.Hosted_Services;

public class DatabaseClearJob : IHostedService
{
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public DatabaseClearJob(
        ILogger<DatabaseClearJob> logger, 
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    private bool _run;

    private async Task Run()
    {
        while(_run)
        {
            var scope = _serviceProvider.CreateScope();
            var dbContext = scope
                .ServiceProvider
                .GetRequiredService<ToDoDbContext>();
            await Task.Delay(TimeSpan.FromSeconds(5));
            _logger.LogError("Transaction Service is running");
            _logger.LogCritical($"Todos count:  {dbContext.ToDoItems.Count()}");
        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _run = true;
        Run();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _run = false;
        return Task.CompletedTask;
    }
}
