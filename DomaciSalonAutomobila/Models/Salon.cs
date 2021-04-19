using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciSalonAutomobila.Models
{
    public class Salon
    {
        [Required(ErrorMessage = "obavezno polje- server!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public string PIB { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public string City { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public string Address { get; set; }
        public virtual ICollection<Automobile> Automobiles { get; set; }
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }

    }
}