using System.ComponentModel.DataAnnotations;

namespace React2.Models;

//Tre val för status av Todo objektet
public enum TodoStatus
{
    NotStarted,
    InProgress,
    Completed
}
public class TodoModel
{
    //Properties
    //Id som heltal
    public int Id { get; set; }

    //Namn med validering (Minst 3 tecken)
    [Required]
    [MinLength(3)]
    public string? Name { get; set; }

    //Beskrivning med validering (max 200 tecken)
    [MaxLength(200)]
    public string? description { get; set; }

    //Status med 3 val enligt enum, sätts till NotStarted
    public TodoStatus Status { get; set; } = TodoStatus.NotStarted;
}