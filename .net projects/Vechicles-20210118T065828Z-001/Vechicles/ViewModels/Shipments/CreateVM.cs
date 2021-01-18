using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vechicles.ViewModels.Shipments
{
    public class CreateVM
    {
        [DisplayName("Package: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Package { get; set; }

        [DisplayName("From: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string From { get; set; }

       
        [DisplayName("Destination: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Destination { get; set; }

        [DisplayName("PriceOfPacket: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public double PriceOfPacket { get; set; }
    }
}