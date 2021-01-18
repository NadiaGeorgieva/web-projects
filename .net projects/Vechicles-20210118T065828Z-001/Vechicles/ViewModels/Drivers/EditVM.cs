using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vechicles.ViewModels.Drivers
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Name: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Name { get; set; }

        [DisplayName("Age: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public int Age { get; set; }

        [DisplayName("DrivingLicence: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string DrivingLicence { get; set; }
    }
}