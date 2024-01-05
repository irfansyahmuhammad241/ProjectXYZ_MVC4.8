using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Models
{
    public class Project
    {
        [Key]
        [Column("ProjectID", TypeName = "int")]
        public int ProjectID { get; set; }
        [Column("name", TypeName = "nvarchar(max)")]
        public string ProjectName { get; set; }

        // Foreign Key
        [Column("VendorID")]
        public int VendorID { get; set; }

        // Cardinality
        public Vendor Vendor { get; set; }
    }
}