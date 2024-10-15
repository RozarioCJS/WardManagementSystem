namespace PatientCareSubsystem.UI.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Add any other properties if needed

        public int DoctorID { get; set; }       //to allow for a specific doctor's information to be displayed 
                                                //when that doctor logs in.
        public string LastName { get; set; }    //get the doctors last name to display in nav. bar
    }
}
