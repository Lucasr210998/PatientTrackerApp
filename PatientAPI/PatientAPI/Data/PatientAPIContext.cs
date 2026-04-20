using PatientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientAPI.Data
{
    public class PatientAPIContext: DbContext
    {
        public PatientAPIContext(DbContextOptions<PatientAPIContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }

    }
}
