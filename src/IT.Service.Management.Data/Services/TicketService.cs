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
