

using System;
using System.Threading.Tasks;

namespace Quartz.Demo
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var agentId = context.JobDetail.JobDataMap.GetString("agentId");
            var jobGuid = Guid.Parse(context.JobDetail.Key.Name);
            await Console.Out.WriteLineAsync($"Agent guid is {agentId} and Job guid is {jobGuid}");
        }
    }
}
