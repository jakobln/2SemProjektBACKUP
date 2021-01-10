namespace EFWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int BookingID { get; set; }

        [Required]
        [StringLength(50)]
        public string KundeEmail { get; set; }

        public DateTime? BookTime { get; set; }

        [StringLength(50)]
        public string KundeNavn { get; set; }

        [StringLength(50)]
        public string ForhandlerNavn { get; set; }

        [StringLength(50)]
        public string BilModel { get; set; }
    }
}
