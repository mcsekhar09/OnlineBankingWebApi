using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineBanking.Models
{
    public partial class AccountRequest
    {
        public AccountRequest()
        {
            Account = new HashSet<Account>();
        }

        public int RequestId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string MobileNum { get; set; }
        public string EmailId { get; set; }
        public long? AddharCard { get; set; }
        public DateTime? Dob { get; set; }
        public string ResidentialAddress { get; set; }
        public string PermenentAddress { get; set; }
        public string OccupationalDetails { get; set; }
        public double? GrossAnnualIncome { get; set; }
        public string DebitAtmcard { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
