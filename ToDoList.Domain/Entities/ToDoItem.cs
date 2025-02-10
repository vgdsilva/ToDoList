using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Domain.Entities;

[Table("todoitem")]
public class ToDoItem
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.Empty;

    [StringLength(255, MinimumLength = 1)]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("observation")]
    [StringLength(255)]
    public string Observation { get; set; } = string.Empty;

    [Column("iscompleted")]
    public bool IsCompleted { get; set; } = false;

    public ToDoItem()
    {
        
    }
}
