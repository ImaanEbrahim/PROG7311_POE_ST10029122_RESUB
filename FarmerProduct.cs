using System;
using System.ComponentModel.DataAnnotations;

namespace PROG3A_POE.Models
{
    public class FarmerProduct
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        // to show what farmer logged in
        public string FarmerId { get; set; }
    }
}
