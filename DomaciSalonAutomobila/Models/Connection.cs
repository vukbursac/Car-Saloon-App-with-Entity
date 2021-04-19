using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciSalonAutomobila.Models
{
    public class Connection
    {
        [Required(ErrorMessage = "obavezno polje- server!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public virtual int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        [Required(ErrorMessage = "obavezno polje- server!")]
        public virtual int SalonId { get; set; }
        public virtual Salon Salon { get; set; }
    }
}