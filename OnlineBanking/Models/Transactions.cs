using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineBanking.Models
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public long? FromAcc { get; set; }
        public long? ToAcc { get; set; }
        public int? CustomerId { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionType { get; set; }
        public string Remark { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual Account Customer { get; set; }
    }
}
