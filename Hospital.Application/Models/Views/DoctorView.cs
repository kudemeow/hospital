namespace Hospital.Application.Models.Views;

public class DoctorView : BaseEntityView
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FatherName { get; set; }
    public int SpecializationId { get; set; }
    public int OfficeId { get; set; }
    public int UnitId { get; set; }
    public bool IsUnitDoctor { get; set; }
}