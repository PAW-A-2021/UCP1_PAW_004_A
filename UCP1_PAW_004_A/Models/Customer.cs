using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_004_A.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Penyewaans = new HashSet<Penyewaan>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }

        public virtual ICollection<Penyewaan> Penyewaans { get; set; }
    }
}
