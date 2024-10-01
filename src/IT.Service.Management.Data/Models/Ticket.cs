using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IT.Service.Management.Data.Models;

[Collection("Tickets")]
public class Ticket
{
    public ObjectId Id { get; set; }

    [Required(ErrorMessage = "The Title is required")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Description is required")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Created Date is required")]
    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

}
