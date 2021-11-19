using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_004_A.Models
{
    public partial class Komik
    {
        public Komik()
        {
            Penyewaans = new HashSet<Penyewaan>();
        }

        public int NoKomik { get; set; }
        public string NamaKomik { get; set; }
        public string Pengarang { get; set; }
        public string Penerbit { get; set; }

        public virtual ICollection<Penyewaan> Penyewaans { get; set; }
    }
}
