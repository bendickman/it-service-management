using IT.Service.Management.Data.Context;
using IT.Service.Management.Data.Models;

namespace IT.Service.Management.Data;

public class Seed
{
    public static async Task SeedData(
        ApplicationDbContext context)
    {
        if (context.Tickets.Any())
        {
            return;
        }

        var tickets = new List<Ticket>
        {
            new Ticket
            {
                CreatedDate = DateTime.Now.AddDays(-5),
                Title = "Test Ticket 1",
                Description = "Lorem ipsum dolor sit amet consectetur adipiscing elit mauris per donec, venenatis fames mollis inceptos a lacus et nec pulvinar cubilia nisl, fermentum ornare viverra facilisi placerat ut class cum magna. Integer cubilia senectus",
            },
            new Ticket
            {
                CreatedDate = DateTime.Now.AddDays(-10),
                Title = "Test Ticket 2",
                Description = "curae suspendisse potenti quis dapibus condimentum litora, sed sodales fringilla blandit cursus pharetra dictumst sociosqu netus placerat, convallis pulvinar ut tempus at non sapien taciti",
            },
            new Ticket
            {
                CreatedDate = DateTime.Now.AddDays(-15),
                Title = "Test Ticket 3",
                Description = " Auctor placerat taciti tempor laoreet quisque felis quis varius, erat elementum sodales ante semper montes sapien, penatibus urna blandit praesent eu conubia augue. Quis ad cum hendrerit",
            },
        };

        await context.Tickets.AddRangeAsync(tickets);
        await context.SaveChangesAsync();
    }
}
