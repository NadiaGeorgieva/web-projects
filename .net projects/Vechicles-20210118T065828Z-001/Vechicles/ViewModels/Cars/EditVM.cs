using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vechicles.ViewModels.Cars
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Brand: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Brand { get; set; }

        [DisplayName("Color: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Color { get; set; }

        [DisplayName("FullDescription: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FullDescription { get; set; }

    }
}