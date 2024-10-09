using Ardalis.ApiEndpoints;
using IT.Service.Management.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT.Service.Management.UI.Endpoints.Ticket.Add;

[Route("v1/ticket")]
public class AddTicketEndpoint : EndpointBaseAsync.WithRequest<AddTicketRequest>.WithActionResult
{
    private readonly ITicketService _ticketService;

    public AddTicketEndpoint(
        ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public override async Task<ActionResult> HandleAsync(
        [FromBody] AddTicketRequest request,
        CancellationToken cancellationToken = default)
    {
        var ticket = new Data.Models.Ticket
        {
            Title = request.Title,
            Description = request.Description,
        };

        await _ticketService.AddTicketAsync(ticket, cancellationToken);

        return Ok();
    }
}
