using System.ComponentModel.DataAnnotations;

namespace Entity.Data.Entity;

public class Nation
{
    [Key]
    public int Id { get; set; }

    public string NationName { get; set; } = "";

}
