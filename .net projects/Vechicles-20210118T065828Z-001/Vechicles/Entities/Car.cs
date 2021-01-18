using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vechicles.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string FullDescription { get; set; }
      

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
    }
}