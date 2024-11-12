using FluentValidation;
using IT.Service.Management.UI.Shared.Models;

namespace IT.Service.Management.UI.Shared.FormModels;

public class TicketValidator : AbstractValidator<Ticket>
{
    public TicketValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please enter a Title");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a Description");
    }
}