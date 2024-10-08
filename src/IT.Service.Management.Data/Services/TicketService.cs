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

    public void AddTicket(
        Ticket ticket)
    {
        _dbContext.Tickets.Add(ticket);
        _dbContext.ChangeTracker.DetectChanges();

        _dbContext.SaveChanges();
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
