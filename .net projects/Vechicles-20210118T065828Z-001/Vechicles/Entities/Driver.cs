using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vechicles.Entities
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DrivingLicence { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
    }
}