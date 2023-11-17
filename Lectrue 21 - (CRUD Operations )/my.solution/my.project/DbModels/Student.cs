using System;
using System.Collections.Generic;

namespace my.project.DbModels
{
    public partial class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string RoleNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
