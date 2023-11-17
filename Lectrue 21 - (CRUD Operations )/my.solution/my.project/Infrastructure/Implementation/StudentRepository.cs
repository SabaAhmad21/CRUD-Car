
using Microsoft.EntityFrameworkCore;
using my.project.Infrastructure.Interfaces;
using my.project.ViewModels;

namespace my.project.Infrastructure.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly my.project.DbModels.EVS407Context _context;
        private readonly List<Student> _students;
        public StudentRepository(my.project.DbModels.EVS407Context context)
        {
            _context = context;
            _students = new List<Student>();
            _students.Add(new Student()
            {
                Department = "SE",
                Id = 1,
                PhoneNumber = "1234567890",
                RoleNumber = "1234567890",
                StudentName = "Elan",
            });
            _students.Add(new Student()
            {
                Department = "SE",
                Id = 2,
                PhoneNumber = "1234567890",
                RoleNumber = "1234567890",
                StudentName = "Elan",
            });
            _students.Add(new Student()
            {
                Department = "SE",
                Id = 3,
                PhoneNumber = "1234567890",
                RoleNumber = "1234567890",
                StudentName = "Elan",
            });
        }
        public IEnumerable<Student> StudentGetAll()
        {
            var students = new List<Student>();
            var student = _context.Students.ToList();
            if (student != null && student.Count() > 0)
            {
                foreach (var item in student)
                {
                    students.Add(new Student()
                    {
                        Department = item.Department,
                        Id = item.Id,
                        PhoneNumber = item.PhoneNumber,
                        RoleNumber = item.RoleNumber,
                        StudentName = item.StudentName,
                    });
                }
            }
            return students;
        }
        public bool StudentCreate(StudentCrateVM student)
        {
            var nextId = _students.Count;
            _students.Add(new Student()
            {
                Department = student.Department,
                PhoneNumber = student.PhoneNumber,
                RoleNumber = student.RoleNumber,
                StudentName = student.StudentName,
                Id = nextId + 1
            });
            return true;
        }
        public bool IsRoleNumberExist(string RollNumber)
        {
            if (_students.Where(p => p.RoleNumber.Equals(RollNumber)).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool StudentDelete(int id)
        {
            var student = _students.Where(p => p.Id == id).FirstOrDefault();

            return student != null ? _students.Remove(student) : false;
            //if(student != null)
            //{
            //    _students.Remove(student);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public StudentUpdateM StudentGetById(int id)
        {
            var student = _students.Where(p => p.Id == id).FirstOrDefault();
            //return student == null ? null : new StudentUpdateM()
            //{
            //    Department = student.Department,
            //    PhoneNumber = student.PhoneNumber,
            //    RoleNumber = student.RoleNumber,
            //    StudentId = student.Id,
            //    StudentName = student.StudentName
            //};
            if (student != null)
            {
                return new StudentUpdateM()
                {
                    StudentName = student.StudentName,
                    StudentId = student.Id,
                    Department = student.Department,
                    RoleNumber = student.RoleNumber,
                    PhoneNumber = student.PhoneNumber,
                };
            }
            else
            {
                return null;
            }
        }
        public bool StudentUpdate(StudentUpdateM model)
        {
            var student = _students.Where(p => p.Id == model.StudentId).FirstOrDefault();
            if (student != null)
            {
                student.PhoneNumber = model.PhoneNumber;
                student.StudentName = model.StudentName;
                student.Department = model.Department;
            }
            return true;
        }
    }
}
