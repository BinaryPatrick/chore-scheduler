using House.Chore.Common.Models;
using House.Chore.Data.Models;
using Microsoft.Extensions.Logging;

namespace House.Chore.Data.Services
{
    internal class TaskTemplateService
    {
        private readonly HouseChoreContext choreContext;
        private readonly ILogger logger;

        public TaskTemplateService(ILogger<TaskTemplateService> logger, HouseChoreContext choreContext)
        {
            this.choreContext = choreContext;
            this.logger = logger;
        }

        public IEnumerable<TaskTemplate> GetTaskTemplates()
            => choreContext.TaskTemplates.ToList();

        public TaskTemplate? GetTaskTemplate(int taskTemplateId)
            => choreContext.TaskTemplates
                .Where(x => x.TaskTemplateId == taskTemplateId)
                .FirstOrDefault();
    }
}
