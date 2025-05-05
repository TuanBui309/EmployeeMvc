using System.ComponentModel.DataAnnotations;
namespace Entity.Models;

public class District
{
    [Key]
    public int Id { get; set; }

    public int CityId { get; set; }

    public string DistrictName { get; set; } = "";

    public City? City { get; set; }

    public ICollection<Ward>? Wards { get; set; }

}
