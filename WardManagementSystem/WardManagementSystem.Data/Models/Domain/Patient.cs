using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int AllergyId { get; set; }

        public string Gender { get; set; }

        public int ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public int WardId { get; set; }

    }
}
