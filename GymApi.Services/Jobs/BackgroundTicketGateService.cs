using GymApi.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GymApi.UseCases.Jobs;

public class BackgroundTicketGateService : BackgroundService
{
    private readonly ILogger<BackgroundTicketGateService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public BackgroundTicketGateService(ILogger<BackgroundTicketGateService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var scopedService = scope.ServiceProvider.GetRequiredService<ITicketGate>();
            var users = scopedService.UpdateTicketGate();
            Console.WriteLine(string.Join(", ", users));
            await Task.Delay(20000000, stoppingToken);
        }
    }
}