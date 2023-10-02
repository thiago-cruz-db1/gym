using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace GymApi.UseCases.Jobs;

public class TicketGateJobConfig
{
    public static IJobDetail ConfigureJob()
    {
        return JobBuilder.Create<TicketGateJob>()
            .WithIdentity("job1", "group1")
            .Build();
    }

    public static ITrigger ConfigureTrigger()
    {
        return TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(2)
                .RepeatForever())
            .Build();
    }
}