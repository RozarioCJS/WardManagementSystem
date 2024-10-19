using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Bed
    {
        [Required]
        public int BedId { get; set; }
        [Required]
        public int PatientId { get; set; }
        public int WardId { get; set; }
        public string Status { get; set; }

    }
}
