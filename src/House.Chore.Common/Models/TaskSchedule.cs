namespace House.Chore.Common.Models;

public partial class TaskSchedule
{
    public int TaskId { get; set; }

    public DateTime TaskDate { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime ModifiedOn { get; set; }
}
