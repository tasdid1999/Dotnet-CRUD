using QuadTheoryTestProject.Models;
using QuadTheoryTestProject.Models.ViewModel;

namespace QuadTheoryTestProject.Repository.InterFace
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(StudentViewModel student);
        Task<IEnumerable<StudentViewModel>> GetAllStudentAsync();
        Task<StudentViewModel> GetStudentByIdAsync(Guid id);
        Task<Student> DeleteStudentAsync(Guid studnetId);
        Task<Student> UpdateStudentAsync(StudentViewModel student);
   

    }
}
