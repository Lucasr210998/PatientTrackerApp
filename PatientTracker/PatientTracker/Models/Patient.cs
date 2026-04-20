using System.ComponentModel.DataAnnotations;

namespace PatientTracker.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Symptoms are required")]
        public string Symptoms { get; set; }

        [Range(1, 9999, ErrorMessage = "Bed number must be valid")]
        public int BedNumber { get; set; }
    }
}
