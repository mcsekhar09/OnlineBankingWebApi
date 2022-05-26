using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineBanking.Models
{
    public partial class Account
    {
        public Account()
        {
            Beneficiary = new HashSet<Beneficiary>();
            Transactions = new HashSet<Transactions>();
        }

        public int CustomerId { get; set; }
        public int? RequestId { get; set; }
        public string Password { get; set; }
        public long? AccountNum { get; set; }
        public decimal? Balance { get; set; }
        public string TransactionPassword { get; set; }

        public virtual AccountRequest Request { get; set; }
        public virtual ICollection<Beneficiary> Beneficiary { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
