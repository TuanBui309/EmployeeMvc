using System.ComponentModel.DataAnnotations;
namespace Entity.Data.Entity;

public class Job
{
    [Key]
    public int Id { get; set; }

    public string JobName { get; set; } = "";

}
