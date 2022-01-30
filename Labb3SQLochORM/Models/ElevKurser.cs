using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3SQLochORM.Models
{
    public partial class ElevKurser
    {
        public int? FElevId { get; set; }
        public int? FKursId { get; set; }
        public string FKursBetyg { get; set; }
        public DateTime? BetygDatum { get; set; }

        public virtual Elev FElev { get; set; }
        public virtual Kurs FKurs { get; set; }
    }
}
