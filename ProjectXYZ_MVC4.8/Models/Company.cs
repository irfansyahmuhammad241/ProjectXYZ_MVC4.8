using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Models
{
    public class Company
    {
        [Key]
        [Column("CID")]
        public int ID { get; set; }
        [Column("CompanyName", TypeName = "nvarchar(max)")]
        public string CompanyName { get; set; }
        [Column("CompanyEmail")]
        public string CompanyEmail { get; set; }
        [Column("Phone", TypeName = "nvarchar")]  
        public string CompanyPhoneNumber { get; set; }
        [Column("ApprovalStatus", TypeName = "nvarchar")]
        public string ApprovalStatus { get; set; }
        [Column("CompanyPhoto")]
        public byte[] CompanyPhoto { get; set; }

        public User User { get; set; }
    }
}