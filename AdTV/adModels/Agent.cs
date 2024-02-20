using System;
using System.Collections.Generic;

namespace EmerAgency.adModels;

public partial class Agent
{
    public int AgentCode { get; set; }

    public string? Name { get; set; }

    public string? BankDetails { get; set; }

    public string? Phone { get; set; }

    public string? ContactPerson { get; set; }

    public decimal? CommissionRate { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; } = new List<Advertisement>();
}
