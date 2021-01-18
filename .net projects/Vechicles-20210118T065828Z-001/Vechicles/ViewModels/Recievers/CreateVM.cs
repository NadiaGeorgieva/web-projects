using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vechicles.ViewModels.Recievers
{
    public class CreateVM
    {
        public int OwnerListId { get; set; }
        [DisplayName("FirstName: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FirstName { get; set; }

        [DisplayName("LastName: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string LastName { get; set; }

      
    }
}