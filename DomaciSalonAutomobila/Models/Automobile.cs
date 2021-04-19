using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomaciSalonAutomobila.Models
{
    public class Automobile
    {
        [Required(ErrorMessage = "obavezno polje- server!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public int Year { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public double Power { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public string Color { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public virtual int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public virtual int SalonId { get; set; }
        public virtual Salon Salon { get; set; }

    }
}