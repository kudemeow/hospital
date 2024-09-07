using Hospital.Domain.Models.Entities;

namespace Hospital.Domain.Models.Entities;

public class Unit : BaseEntity
{
    public int Number { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }
}