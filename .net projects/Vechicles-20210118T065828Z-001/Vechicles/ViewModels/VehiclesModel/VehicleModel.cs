using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vechicles.ViewModels.VehiclesModel
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }

        [DisplayName("VehicleName")]
        public string VehicleName { get; set; }
        public Vehicle Type { get; set; }
        public enum Vehicle
        {
            bus,
            van,
            motor,
            car,
            truck,
            plane
        }
    }
}