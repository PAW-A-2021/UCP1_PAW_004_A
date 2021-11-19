using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_004_A.Models
{
    public partial class Penyewaan
    {
        public int IdSewa { get; set; }
        public DateTime? Tanggal { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdAdmin { get; set; }
        public int? NoKomik { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Komik NoKomikNavigation { get; set; }
    }
}
