using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HttpPatchExample.Models;

public class Person
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20)]
    public string FirstName { get; set; }
 
    [MaxLength(20)]
    public string OldFirstName { get; set; }
    [Required]
    [MaxLength(20)]
    public string LastName { get; set; }
    [MaxLength(20)]
    public string OldLastName { get; set; }
    public bool IsActive { get; set; }
   
    
}