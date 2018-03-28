using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OhmCalculator.Web.Models
{
    public class LookupOhmModel
    {
        [Required]
        public string BandAColor { get; set; }
        [Required]
        public string BandBColor { get; set; }
        [Required]
        public string BandCColor { get; set; }
        [Required]
        public string BandDColor { get; set; }

    }
}