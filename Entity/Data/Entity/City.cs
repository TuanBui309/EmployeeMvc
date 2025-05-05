using System.ComponentModel.DataAnnotations;
namespace Entity.Data.Entity;

public class City
{
	[Key]
        public int Id { get; set; }

	public string CityName { get; set; } = "";

	public ICollection<District>? Districts { get; set; }
}

