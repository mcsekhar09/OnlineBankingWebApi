using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineBanking.Models
{
    public partial class Beneficiary
    {
        public int BeneficiaryId { get; set; }
        public int? CustomerId { get; set; }
        public long? BeneficiaryAccNo { get; set; }
        public string IfscCode { get; set; }
        public string Nickname { get; set; }

        public virtual Account Customer { get; set; }
    }
}
