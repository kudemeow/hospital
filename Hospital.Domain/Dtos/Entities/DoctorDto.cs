namespace Hospital.Domain.Dtos.Entities;

public class DoctorDto : BaseEntityDto
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FatherName { get; set; }
    public int SpecializationId { get; set; }
    public int OfficeId { get; set; }
    public int UnitId { get; set; }
    public bool IsUnitDoctor { get; set; }
}