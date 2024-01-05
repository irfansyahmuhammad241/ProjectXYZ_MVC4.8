using ProjectXYZ_MVC4._8.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Models
{
    public class User
    {
        [Key]
        [Column("UID", TypeName = "int")]
        public int ID { get; set; }
        [Column("Email", TypeName = "nvarchar(max)")]
        public string Email { get; set; }
        [Column("Password", TypeName = "nvarchar(max)")]
        public string Password { get; set; }
        [Column("UserType")]
        public UserType UserType { get; set; }

        //Foreign Key
        public int CompanyID { get; set; }
        public int ManagerID { get; set; }
        //Cardinality
        public Company Company { get; set; }
        public Manager Manager { get; set; }
        public Vendor Vendor { get; set; }

    }
}