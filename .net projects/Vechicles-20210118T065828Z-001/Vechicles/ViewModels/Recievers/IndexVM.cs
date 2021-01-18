using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vechicles.Entities;

namespace Vechicles.ViewModels.Recievers
{
    public class IndexVM
    {
        public Shipment List { get; set; }
        public List<Reciever> Recievers { get; set; }
    }
}