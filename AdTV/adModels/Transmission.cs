using System;
using System.Collections.Generic;

namespace EmerAgency.adModels;

public partial class Transmission
{
    public int TransmissionCode { get; set; }

    public string? Title { get; set; }

    public int? Rating { get; set; }

    public decimal? CostPerMinute { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; } = new List<Advertisement>();
}
