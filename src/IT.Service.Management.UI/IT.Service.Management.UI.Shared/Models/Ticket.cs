namespace IT.Service.Management.UI.Shared.Models;

public class Ticket
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool HasUpdatedDate => !UpdatedDate?.Equals(DateTime.MinValue) ?? false;
}