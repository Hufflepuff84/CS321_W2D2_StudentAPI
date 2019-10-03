using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W2D2_StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName cannot be empty")]
        [MaxLength(75, ErrorMessage = "FirstName cannot be more than 75 characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName cannot be empty")]
        [MaxLength(75, ErrorMessage = "FirstName cannot be more than 75 characters")]
        public string LastName { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

    }
}
