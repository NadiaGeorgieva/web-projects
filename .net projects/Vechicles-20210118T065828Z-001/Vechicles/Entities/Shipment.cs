using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vechicles.Entities
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Package { get; set; }
        public string From { get; set; }
        public string Destination { get; set; }

        public double PriceOfPacket { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
    }
}