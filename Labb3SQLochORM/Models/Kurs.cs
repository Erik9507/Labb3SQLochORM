using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3SQLochORM.Models
{
    public partial class Kurs
    {
        public int Id { get; set; }
        public string KursNamn { get; set; }
        public int? LärarId { get; set; }

        public virtual Personal Lärar { get; set; }
    }
}
