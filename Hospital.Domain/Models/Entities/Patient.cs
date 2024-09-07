namespace Hospital.Domain.Models.Entities;

public class Patient : BaseEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string FatherName { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }


    // Patient -> Unit
    public int UnitId { get; set; }
    public virtual Unit Unit { get; set; }
}