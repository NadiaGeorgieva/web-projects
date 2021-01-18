using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vechicles.Entities
{
    public class Reciever
    {
        [Key]
        public int Id { get; set; }
        public int OwnerListId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("OwnerListId")]
        public Shipment List { get; set; }
    }
}