using DistributorAPI.Application.OrderUseCases;

namespace DistributorAPI.Infrastructure.BackgroundServices;

public class OrderProcessingBackgroundService(OrderProcessingService orderProcessingService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await orderProcessingService.ProcessPendingOrdersAsync();
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); // Executa a cada 5 minutos
        }
    }
}
