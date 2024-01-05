using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Models
{
    public class Manager
    {
        [Key]
        [Column("MID", TypeName = "int")]
        public int ID { get; set; }
        [Column("ManagerName", TypeName = "nvarchar")]
        public string ManagerName { get; set; }
        [Column("ManagerEmail", TypeName = "nvarchar")]
        public string ManagerEmail { get; set; }
        [Column("ManagerPhone", TypeName = "nvarchar")]
        public string ManagerPhone { get; set; }

        //Cardinality
        public User User { get; set; }
    }
}