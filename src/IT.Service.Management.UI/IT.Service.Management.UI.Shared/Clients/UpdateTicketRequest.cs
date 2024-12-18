﻿namespace IT.Service.Management.UI.Shared.Clients;

public class UpdateTicketRequest
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}