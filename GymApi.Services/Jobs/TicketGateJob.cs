using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace GymApi.UseCases.Jobs;

public class TicketGateJob : IJob
{

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            Console.WriteLine("on job");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}