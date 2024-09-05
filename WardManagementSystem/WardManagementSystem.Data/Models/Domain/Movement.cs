using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Movement
    {
        [Required]
        public int PatientMovementId { get; set; }
        [Required]
        public string Loccation { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public int PatientId { get; set; }
    }
}
