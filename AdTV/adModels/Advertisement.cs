using System;
using System.Collections.Generic;

namespace EmerAgency.adModels;

public partial class Advertisement
{
    public int AdCode { get; set; }

    public int? TransmissionCode { get; set; }

    public int? ClientCode { get; set; }

    public DateOnly? DateConclusion { get; set; }

    public int? Duration { get; set; }

    public int? AgentCode { get; set; }

    public virtual Agent? AgentCodeNavigation { get; set; }

    public virtual Client? ClientCodeNavigation { get; set; }

    public virtual Transmission? TransmissionCodeNavigation { get; set; }
}
