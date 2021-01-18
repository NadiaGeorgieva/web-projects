using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vechicles.Entities;

namespace Vechicles.ViewModels.Shipments
{
    public class ShareVM
    {
        public Shipment List { get; set; }
        public List<Share> Shares { get; set; }
        public List<User> Users { get; set; }
    }
}