using IT.Service.Management.Data.Context;
using IT.Service.Management.Data.Interfaces;
using IT.Service.Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IT.Service.Management.Data.Services;

public class TicketService : ITicketService
{
    private readonly ApplicationDbContext _dbContext;

    public TicketService(
        ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTicketAsync(
        Ticket ticket,
        CancellationToken cancellationToken)
    {
        ticket.CreatedDate = DateTime.UtcNow;

        await _dbContext.Tickets.AddAsync(ticket, cancellationToken);
        _dbContext.ChangeTracker.DetectChanges();

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTicketAsync(
        Ticket ticket,
        CancellationToken cancellationToken)
    {
        var currentTicket = await GetTicketAsync(ticket.Id);

        if (currentTicket is null)
        {
            throw new KeyNotFoundException("Ticket not found");
        }

        currentTicket.Title = ticket.Title;
        currentTicket.Description = ticket.Description;
        currentTicket.UpdatedDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTicketAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var ticket = await GetTicketAsync(id);

        if (ticket is null)
        {
            return;
        }

        _dbContext
           .Tickets
           .Remove(ticket);

        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<Ticket> GetAllTickets()
    {
        return _dbContext
            .Tickets
            .OrderBy(t => t.Id)
            .AsNoTracking()
            .AsEnumerable<Ticket>();
    }

    public Task<Ticket?> GetTicketAsync(
        Guid id)
    {
        return _dbContext
            .Tickets
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
