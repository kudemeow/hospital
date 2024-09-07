namespace Hospital.Domain.Models.Entities;

public class Office : BaseEntity
{
    public int Number { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; }
}