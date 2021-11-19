using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_004_A.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Penyewaans = new HashSet<Penyewaan>();
        }

        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; }

        public virtual ICollection<Penyewaan> Penyewaans { get; set; }
    }
}
