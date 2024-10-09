using System.ComponentModel.DataAnnotations;

namespace IT.Service.Management.UI.Endpoints.Ticket.Add;

public class AddTicketRequest
{
    [Required(ErrorMessage = "The Title is required")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Description is required")]
    public string Description { get; set; } = string.Empty;
}