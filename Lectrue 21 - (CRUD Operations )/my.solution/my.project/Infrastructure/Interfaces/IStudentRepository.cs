using my.project.ViewModels;

namespace my.project.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> StudentGetAll();
        bool StudentCreate(StudentCrateVM student);
        bool IsRoleNumberExist(string RollNumber);
        bool StudentDelete(int id);
        StudentUpdateM StudentGetById(int id);
        bool StudentUpdate(StudentUpdateM model);
    }
}
