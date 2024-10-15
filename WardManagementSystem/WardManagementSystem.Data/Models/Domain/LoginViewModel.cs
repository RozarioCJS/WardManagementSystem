namespace PatientCareSubsystem.UI.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string LastName { get; set; }
        public int DoctorID { get; set; }
        public int ConsumableManagerID { get; set; }
        public int PrescriptionManagerID { get; set; }
    }
}
