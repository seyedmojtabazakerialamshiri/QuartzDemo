using System;
using System.Threading.Tasks;
using Quartz.Impl;

namespace Quartz.Demo
{
    class Program
    {
        /// <summary>
        /// https://www.freeformatter.com/cron-expression-generator-quartz.html
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            var jobGuid = Guid.NewGuid().ToString();

            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();

            await scheduler.Start();

            var job = JobBuilder.Create<HelloJob>()
                .WithIdentity(jobGuid).UsingJobData("agentId", "123")
                .Build();

            var trigger = TriggerBuilder.Create().StartNow()
                .WithCronSchedule("0 * * ? * *")
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            Console.ReadLine();
            Console.WriteLine("Press any key to close the application");

            await scheduler.Shutdown();

        }
    }
}
