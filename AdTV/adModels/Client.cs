using System;
using System.Collections.Generic;

namespace EmerAgency.adModels;

public partial class Client
{
    public int ClientCode { get; set; }

    public string? Name { get; set; }

    public string? BankDetails { get; set; }

    public string? Phone { get; set; }

    public string? ContactPerson { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; } = new List<Advertisement>();
}
