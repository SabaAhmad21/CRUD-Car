using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace my.project.ViewModels
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set; }
        public string RoleNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class StudentCrateVM
    {
        [Required(ErrorMessage ="Student Name is required!")]
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [Required(ErrorMessage ="Student Departement is required!")]
        public string Department { get; set; }
        [Required(ErrorMessage ="Student Roll Number is required!")]
        [DisplayName("Role Number")]
        [Remote("IsRoleNumberExist", "Student", ErrorMessage = "Roll Number already exists!")]
        public string RoleNumber { get; set; }
        [Required(ErrorMessage ="Student Phone number is required!")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
    public class StudentUpdateM
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student Name is required!")]
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Student Departement is required!")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Student Roll Number is required!")]
        [DisplayName("Role Number")]
        [Remote("IsRoleNumberExist", "Student", ErrorMessage = "Roll Number already exists!")]
        public string RoleNumber { get; set; }
        [Required(ErrorMessage = "Student Phone number is required!")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
