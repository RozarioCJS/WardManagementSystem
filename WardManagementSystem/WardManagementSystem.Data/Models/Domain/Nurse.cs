using System.ComponentModel.DataAnnotations;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Nurse
    {
        public int NurseId { get; set; }
         
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email {  get; set; }

    }
}
