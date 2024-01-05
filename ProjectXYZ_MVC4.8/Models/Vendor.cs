using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Models
{
    public class Vendor
    {
        [Key]
        [Column("VendorID", TypeName = "int")]
        public int VendorID { get; set; }

        [Column("vendorName", TypeName = "nvarchar(max)")]
        public string VendorName { get; set; }

        [Column("businessType", TypeName = "nvarchar")]
        public string BusinessType { get; set; }

        [Column("companyType", TypeName = "nvarchar")]
        public string CompanyType { get; set; }

        // Foreign Key
        public int UserID { get; set; }

        // Cardinality
        public User User { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}