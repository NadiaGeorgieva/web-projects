using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vechicles.Entities
{
    public class Share
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ToDoListId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ToDoListId")]
        public virtual Shipment List { get; set; }
    }
}