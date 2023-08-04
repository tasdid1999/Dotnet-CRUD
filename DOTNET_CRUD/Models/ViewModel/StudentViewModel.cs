
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace QuadTheoryTestProject.Models.ViewModel
{
    public class StudentViewModel
    {
       public Guid Id { get; set; }

       [Required]
        public string StudentName { get; set; }

        [Required]
        public int Gender { get; set; }

        public int ClassId { get; set; }

        public string? ClassName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

    }
}
