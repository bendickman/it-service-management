using System.ComponentModel.DataAnnotations;

namespace IT.Service.Management.Data.Models;

public class Comment
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Ticket Id is required")]
    public Guid TicketId { get; set; }

    [Required(ErrorMessage = "The Description is required")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Created Date is required")]
    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
