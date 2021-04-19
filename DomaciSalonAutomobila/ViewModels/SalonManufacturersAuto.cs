using DomaciSalonAutomobila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomaciSalonAutomobila.ViewModels
{
    public class SalonManufacturersAuto
    {
        public Salon Salon { get; set; }
        public Automobile Automobile { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }
}