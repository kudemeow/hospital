namespace Hospital.Domain.Models.Entities;

public class Doctor : BaseEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FatherName { get; set; }
    public bool IsUnitDoctor { get; set; }

    // Doctor -> Specialization
    public int SpecializationId { get; set; }
    public virtual Specialization Specialization { get; set; }

    // Doctor -> Office
    public int OfficeId { get; set; }
    public virtual Office Office { get; set; }

    // Doctor -> Area
    public int UnitId { get; set; }
    public virtual Unit Unit { get; set; }
}