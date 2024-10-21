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
        public DateTime DateTime { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int WardId { get; set; }
        [Required]
        public int BedId { get; set; }
    }
}
