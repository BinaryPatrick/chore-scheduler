namespace House.Chore.Common.Models;

public partial class TaskTemplate
{
    public int TaskTemplateId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public int Frequency { get; set; }

    public DayOfWeek? PreferredDay { get; set; }

    public string? Person { get; set; }

    public DateTime ModifiedOn { get; set; }
}
