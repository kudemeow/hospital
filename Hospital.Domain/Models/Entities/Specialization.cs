namespace Hospital.Domain.Models.Entities;

public class Specialization : BaseEntity
{
    public string Title { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; }
}