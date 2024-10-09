using FluentValidation;

namespace IT.Service.Management.UI.Shared.FormModels;

public class TicketFormModelValidator : AbstractValidator<TicketFormModel>
{
    public TicketFormModelValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Please enter a Title");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a Description");
    }
}

