namespace PatientAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public int Age { get; set; }
        public int BedNumber { get; set; }
        public string Symptoms { get; set; } = null;
    }
}
